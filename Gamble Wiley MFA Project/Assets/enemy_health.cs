using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    public int health;
    public int max_health;
    public float HitDelay; //the amount of time to wait after getting hit
    private bool isDamaged = false;
    private void Awake()
    {
        health = max_health;
    }
    public void take_damage(int damage)
    {
        if(!isDamaged)
        {
            health -= damage;
            if (health <= 0)
            {
                BroadcastMessage("KillEnemy"); //broadcasts the message to kill the enemy to this gameobject
            }
            else
            {
                isDamaged = true;
                Invoke("resetEnemyHealth", HitDelay);
            }
        }
    }
    public void resetEnemyHealth()
    {
        isDamaged = false;
    }
}
