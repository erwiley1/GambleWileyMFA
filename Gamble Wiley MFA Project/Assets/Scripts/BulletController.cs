using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    //private GameObject enemy;
    public int damage;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        damage *= player.GetComponent<PlayerMovement>().attack_damage;
        if (player.GetComponent<PlayerMovement>().shotgun == true) { damage *= 2; }
        StartCoroutine(DeathDelay());
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemy_health>().take_damage(damage); //runs the "take_damage" function on the enemy, with your damage value being sent as the amount of damage
            Destroy(gameObject);
        }
    }
    
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
