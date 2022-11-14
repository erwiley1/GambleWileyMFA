using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    public Transform shotPoint;
    public Transform gun;

    public GameObject EnemyProjectile;

    public float followPlayerRanged;
    public bool inRange;
    public float attackRange;

    public float startTimeBtwnShots;
    private float timeBtwnShots;


    private void Update()
    {
        Vector3 differance = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(differance.x, differance.y) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Vector2.Distance(transform.position, player.position) < followPlayerRanged && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
        }
        else 
        {
            inRange = false;
        }

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if(timeBtwnShots <= 0)
            {
                Instantiate(EnemyProjectile, shotPoint.position, shotPoint.transform.rotation);
                timeBtwnShots = startTimeBtwnShots;

            }
            else
            {
                timeBtwnShots -= Time.deltaTime;
            }
        }

    }

    void FixedUpdate()
    {
     if (inRange) 
        { 
         transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRanged);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }



}
