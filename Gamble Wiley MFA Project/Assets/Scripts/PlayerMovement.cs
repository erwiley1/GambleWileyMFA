using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; //allows us to tweak player momvement speed
    public float moveSpeedMod = 1;
    public Rigidbody2D rb; //reference to RigidBody attached to player

    private Vector2 moveDirection; // Vector2 accounts for movement along 2 axes in a plane

    // Update is called once per frame
    // will be used for processing inputs, ie. whether a button is being pressed
    // not good for calculating physics -- having physics change based on framerate makes them unreliable (glares at Bethesda)
    void Update() 
    {
        ProcessInputs();
    }

    // FixedUpdate is called set amount of times per Update loop
    // will be used for physics calculations, ie. movement and collision
    void FixedUpdate() 
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // determines left/right movement based on key press
        float moveY = Input.GetAxisRaw("Vertical"); // determines up/down movement based on key press
        // GetAxisRaw generates either -1, 0, or 1 rather than any value between -1 and 1 (because we're pressing keys rather than tilting a joystick)

        moveDirection = new Vector2(moveX, moveY).normalized; /* converts input into direction
        for diagonal movement, instead of speed being a factor of X and Y movement speeds, will be limited to normal speed; without '.normalized', there's some Pythagorean shit going on */
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed * moveSpeedMod); // takes direction from ProcessInputs, moves player in that direction based on moveSpeed value
    }

    // This PlayerMovement model determines which direction the player should be moving, rather than the location they should be moving towards
    // Admittedly, you could copy the body of both ProcessInputs and Move, then paste them directly into Update and FixedUpdate respectively, forgoing the need for the new methods
    // However, creating new methods and using them in Update and FixedUpdate helps keep things organized
}
