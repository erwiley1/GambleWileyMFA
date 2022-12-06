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

    public GameObject modifiers;

    private void Start()
    {
        modifiers = GameObject.FindGameObjectWithTag("Modifier Manager");
        startTimeBtwnShots /= modifiers.GetComponent<modifiers>().current_enemy_attack_speed;
    }

    void Update()
    {
    // this is the part thats a problem. 
        
        
            Vector3 differance = player.position - transform.position;
            float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg - 0f;
            Quaternion q = Quaternion.AngleAxis(rotZ, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 0 * Time.deltaTime);
        


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
                GameObject bullet = Instantiate(EnemyProjectile, shotPoint.position, shotPoint.transform.rotation);
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
