using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Movement_AI : MonoBehaviour
{
    public Transform target; // player position
    public Animator animator; // grunt animations
    public float speed; // grunt movement speed

    Vector2 playerPos, enemyPos;
    
    void Update()
    {
        if (!animator.GetBool("G_isDead") && target != null) // if B_isDead is false and the player has a position somewhere on the board, then we can do things
        {
            playerPos = new Vector2(target.localPosition.x, target.localPosition.y); // determines position of the player
            enemyPos = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y); // determines position of the grunt

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

        if (animator.GetBool("G_isDead"))
        {
            KillGrunt();
        }
    }
    
    void FixedUpdate()
    {
        if (animator.GetBool("G_isAttack"))
        {
            transform.position = this.transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(enemyPos, playerPos, 2 * Time.deltaTime); // makes the grunt run towards the player
        }
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

    void KillGrunt()
    {
        Destroy(this.gameObject);
    }
}
