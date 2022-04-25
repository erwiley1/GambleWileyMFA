using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Health playerHealth;

    private void Start()
    {
        playerHealth.health = playerHealth.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            this.playerHealth.health -= 10;
            if (playerHealth.health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
