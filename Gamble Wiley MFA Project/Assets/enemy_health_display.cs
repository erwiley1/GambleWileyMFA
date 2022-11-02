using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_display : MonoBehaviour
{
    public GameObject enemy;
    public int health;
    public Text number;

    // Update is called once per frame
    void Update()
    {
        health = enemy.GetComponent<enemy_health>().health;
        number.text = health.ToString();
    }
}
