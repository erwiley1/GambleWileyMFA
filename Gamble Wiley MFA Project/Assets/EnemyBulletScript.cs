using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float lifeTime;
    [SerializeField] Transform target;
    public int damage;



    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        target = GameObject.FindWithTag("Player").transform;
        Invoke("DestroyProjectile", lifeTime);
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
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
