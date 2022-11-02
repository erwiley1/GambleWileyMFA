using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Movement_AI : MonoBehaviour
{
    public Transform target; // player position
    public Animator animator; // grunt animations
    public float speed; // grunt movement speed
    public GameObject coinPrefab;
    public int attack_speed; //currently unused, will be used to determine how fast the enemies attack
    private int spawn_location = 0;
    Vector2 playerPos, enemyPos;
    private GameObject modifiers; // used for modifier application

    private void Awake() //applies the modifiers when this character is spawned
    {
        spawn_location = Random.Range(1, 5); //randomly moves the enemy to one of four preset spawning locations
        switch(spawn_location)
        {
            case 1:
                transform.position = new Vector3(-40, 17, 0);
                break;
            case 2:
                transform.position = new Vector3(40, 17, 0);
                break;
            case 3:
                transform.position = new Vector3(-27, -18, 0);
                break;
            case 4:
                transform.position = new Vector3(25, -17, 0);
                break;
            default:
                break;
        }
        attack_speed = 1;
        modifiers = GameObject.FindGameObjectWithTag("Modifier Manager");
        speed *= modifiers.GetComponent<modifiers>().current_enemy_speed;
        attack_speed *= modifiers.GetComponent<modifiers>().current_enemy_attack_speed;
    }

    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;

        if (!animator.GetBool("G_isDead") && target != null) // if G_isDead is false and the player has a position somewhere on the board, then we can do things
        {
            playerPos = new Vector2(target.localPosition.x, target.localPosition.y); // determines position of the player
            enemyPos = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y); // determines position of the grunt
            
            if (animator.GetBool("G_isAttack"))
            {
                transform.position = this.transform.position;
            }
            if (!animator.GetBool("G_isAttack"))
            {
                transform.position = Vector2.MoveTowards(enemyPos, playerPos, speed * Time.deltaTime);
            }

            // the remainder of this update loop ensures the grunt is facing the correct direction while moving

            float delta_pos_y = Mathf.Abs(Mathf.Abs(target.position.y) - Mathf.Abs(transform.position.y));

            if (target.position.x > transform.position.x)
            {
                if (delta_pos_y > 0.5f)
                {
                    if (target.position.y > transform.position.y)
                    {
                        animator.SetFloat("G_Vertical", 1f);
                        animator.SetFloat("G_Horizontal", 0f);
                    }

                    if (target.position.y < transform.position.y)
                    {
                        animator.SetFloat("G_Vertical", -1f);
                        animator.SetFloat("G_Horizontal", 0f);
                    }
                }
                else
                {
                    animator.SetFloat("G_Vertical", 0f);
                    animator.SetFloat("G_Horizontal", 1f);
                }

                animator.SetFloat("G_Speed", 1f);

            }

            if (target.position.x < transform.position.x)
            {
                if (delta_pos_y > 0.5f)
                {
                    if (target.position.y > transform.position.y)
                    {
                        animator.SetFloat("G_Vertical", 1f);
                        animator.SetFloat("G_Horizontal", 0f);
                    }

                    if (target.position.y < transform.position.y)
                    {
                        animator.SetFloat("G_Vertical", -1f);
                        animator.SetFloat("G_Horizontal", 0f);
                    }
                }
                else
                {
                    animator.SetFloat("G_Vertical", 0f);
                    animator.SetFloat("G_Horizontal", -1f);
                }

                animator.SetFloat("G_Speed", 1f);

            }
        }

        //if (animator.GetBool("G_isDead"))   see enemy_health.cs
        //{
        //    KillGrunt();
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (animator.GetBool("G_isAttack") == false)
            {
                animator.SetBool("G_isAttack", true);
            }
        }
    }

    void G_StopAttack()
    {
        if (animator.GetBool("G_isAttack")) { animator.SetBool("G_isAttack", false); }
    }

    public void KillEnemy()
    {
        Instantiate(coinPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
