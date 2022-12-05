using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float lifeTime;
    [SerializeField] Transform target;
    public int damage;
    public bool direction;
    int travelDirectiony = 1;
    int travelDirectionx = 1;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        target = GameObject.FindWithTag("Player").transform;
        Invoke("DestroyProjectile", lifeTime);

        if (target.position.y > transform.position.y)
        {
            travelDirectiony = 1;
        }
        else
        {
            travelDirectiony = -1;
        }

        if (target.position.x > transform.position.x)
        {
            travelDirectionx = 1;
        }
        else
        {
            travelDirectionx = -1;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Player")
        {
          //  
            Destroy(gameObject);
        }
    }

   


    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * travelDirectionx * bulletSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * travelDirectiony * .5625f * bulletSpeed * Time.deltaTime);
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
