using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float rotateForce = 10;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * (Random.Range(-3f, 3f) + rotateForce));//rotate coin randomly
    }
}
