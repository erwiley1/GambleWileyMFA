using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AimTest : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 differance = player.position - transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg - 0f;
        Quaternion q = Quaternion.AngleAxis(rotZ, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 0 * Time.deltaTime);
    }
}
