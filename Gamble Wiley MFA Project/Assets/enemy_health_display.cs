using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_display : MonoBehaviour
{
    public GameObject enemy;
    public int health;
    public Sprite[] health_array;
    public SpriteRenderer health_display;

    // Update is called once per frame
    void Update()
    {
        health = enemy.GetComponent<enemy_health>().health - 1;
        health_display.sprite = health_array[health];
    }
}
