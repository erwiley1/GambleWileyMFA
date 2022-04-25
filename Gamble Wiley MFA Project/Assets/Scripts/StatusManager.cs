using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Health playerHealth;
    public int hitDelay;
    private bool isDamaged = false;

    private void Start()
    {
        playerHealth.health = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!isDamaged)
            {
                isDamaged = true;
                this.playerHealth.health -= 10;
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
