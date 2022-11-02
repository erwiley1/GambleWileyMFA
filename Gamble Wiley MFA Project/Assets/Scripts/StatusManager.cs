using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Health playerHealth;
    public int hitDelay;
    private bool isDamaged = false;
    private int damage;

    private void Start()
    {
        playerHealth.health = playerHealth.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!isDamaged)
            {
                isDamaged = true;
                damage = collision.GetComponent<damage>().attack_damage;
                this.playerHealth.health -= damage;
                if (playerHealth.health <= 0)
                {
                    Destroy(this.gameObject);
                }
                Invoke("resetDamage", hitDelay);
            }
        }
    }

    void resetDamage()
    {
        isDamaged = false;
    }
}
