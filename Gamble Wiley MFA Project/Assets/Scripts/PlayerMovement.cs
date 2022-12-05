using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for convenience sake, player combat is also a part of this script. Might be a good idea to rename whole script to 'PlayerController'

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    
    public int attack_damage = 1; //currently unused, will be used to determine how much damage the attacks do
    public int attack_speed = 1; //currently unused, will be used to determine how fast the player attacks
    
    // variables for movement
    public float moveSpeed; // declaring but not defining allows us to tweak player momvement speed in inspector
    public float moveSpeedMod = 1;
    public Rigidbody2D rb; //reference to RigidBody attached to player

    // variables for ranged weapon combat
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletSpeedMod = 1;
    public float fireDelay;

    // private variables
    private float lastFire;
    private Vector2 moveDirection; // Vector2 accounts for movement along 2 axes in a plane
    private GameObject modifiers; // used for modifier application

    public bool tommygun = true;
    public bool shotgun = false;
    
    private void Awake()
    {
        modifiers = GameObject.FindGameObjectWithTag("Modifier Manager");
        moveSpeedMod *= modifiers.GetComponent<modifiers>().current_player_speed;
        attack_damage *= modifiers.GetComponent<modifiers>().current_player_damage;
        attack_speed *= modifiers.GetComponent<modifiers>().current_player_attack_speed;
        fireDelay /= attack_speed;
    }

    void Update() 
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // determines left/right movement based on key press
        float moveY = Input.GetAxisRaw("Vertical"); // determines up/down movement based on key press
        // GetAxisRaw generates either -1, 0, or 1 rather than any value between -1 and 1 (because we're pressing keys rather than tilting a joystick)
        // This would have to be changed if we want joystick controls rather than keyboard controls

        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 ||
           Input.GetAxisRaw("Horizontal") == -1 ||
           Input.GetAxisRaw("Vertical") == 1 ||
           Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("Last_Horizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("Last_Vertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.Space)) { animator.SetBool("isAttack", true); } // binds the spacebar as the melee attack button

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");

        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay) // this might translate to work with a handheld controller?
        {
            Shoot(shootHor, shootVert);
            lastFire = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(tommygun == true && shotgun == false)
            {
                tommygun = false;
                shotgun = true;
                fireDelay *= 2;
            }
            else if (tommygun == false && shotgun == true)
            {
                tommygun = true;
                shotgun = false;
                fireDelay /= 2;
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized; /* converts input into direction
        for diagonal movement, instead of speed being a factor of X and Y movement speeds, will be limited to normal speed;
        without '.normalized', there's some Pythagorean shit going on */
    }

    void FixedUpdate() 
    {
        //if (animator.GetBool("isAttack") == true)
        //{
        //    rb.velocity = Vector2.zero; // freezes player in place while melee attacking
        //}
        //else if (animator.GetBool("tommygun_attack") == true)
        //{
        //    rb.velocity = Vector2.zero; // freezes player in place while tommy gun attacking
        //}
        //else
        //{
            rb.velocity = new Vector2(moveDirection.x * moveSpeed * moveSpeedMod, moveDirection.y * moveSpeed * moveSpeedMod);
            // takes direction from Update, moves player in that direction based on moveSpeed value
        //}
    }
    
    void Shoot(float x, float y)
    {
        if (tommygun == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject; // makes a bullet
            bullet.AddComponent<Rigidbody2D>().gravityScale = 0; // gives the bullet 0 gravity
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed * bulletSpeedMod : Mathf.Ceil(x) * bulletSpeed * bulletSpeedMod,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed * bulletSpeedMod : Mathf.Ceil(y) * bulletSpeed * bulletSpeedMod
                ); // moves the bullet
            animator.SetBool("tommygun_attack", true);
            animator.SetFloat("horizontalaim", x);
            animator.SetFloat("verticalaim", y);
        }
        else if (shotgun == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject; // makes a bullet
            bullet.AddComponent<Rigidbody2D>().gravityScale = 0; // gives the bullet 0 gravity
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
                (x < 0) ? Mathf.Floor(x) * (bulletSpeed/2) * bulletSpeedMod : Mathf.Ceil(x) * (bulletSpeed/2) * bulletSpeedMod,
                (y < 0) ? Mathf.Floor(y) * (bulletSpeed/2) * bulletSpeedMod : Mathf.Ceil(y) * (bulletSpeed/2) * bulletSpeedMod
                ); // moves the bullet
            animator.SetBool("shotgun_attack", true);
            animator.SetFloat("horizontalaim", x);
            animator.SetFloat("verticalaim", y);
        }
        else
        {

        }
    }

    void StopAttack()
    {
        if (animator.GetBool("isAttack")) { animator.SetBool("isAttack", false); }
        if (animator.GetBool("tommygun_attack")) { animator.SetBool("tommygun_attack", false); }
        if (animator.GetBool("shotgun_attack")) { animator.SetBool("shotgun_attack", false); }
        // returns character to idle state after attacking
    }

    // This PlayerMovement model determines which direction the player should be moving, rather than the location they should be moving towards
}
