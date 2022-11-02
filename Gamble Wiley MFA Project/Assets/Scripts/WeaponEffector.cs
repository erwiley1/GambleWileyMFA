using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffector : MonoBehaviour
{
    public Animator animator;
    //private GameObject enemy;
    public int damage;

    public GameObject player;

    private void Start()
    {
        damage = 1;
        damage *= player.GetComponent<PlayerMovement>().attack_damage;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (animator.GetBool("isAttack"))
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<enemy_health>().take_damage(damage);
            }
        }        
    }

    void Update()
    {
        //    if (animator.GetBool("isAttack"))
        //    {
        //        if (enemy != null)
        //        {
        //            if (!enemy.GetComponent<Animator>().GetBool("G_isDead"))
        //            {
        //                enemy.GetComponent<Animator>().SetBool("G_isDead", true);
        //            }
        //            enemy = null;
        //        }
        //    }
    }
}
