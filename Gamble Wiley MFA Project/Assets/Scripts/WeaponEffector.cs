using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffector : MonoBehaviour
{
    public Animator animator;
    private GameObject enemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject;
        }
    }

    void Update()
    {
        if (animator.GetBool("isAttack"))
        {
            if (enemy != null)
            {
                if (!enemy.GetComponent<Animator>().GetBool("B_isDead"))
                {
                    enemy.GetComponent<Animator>().SetBool("B_isDead", true);
                }
                enemy = null;
            }
        }
    }
}
