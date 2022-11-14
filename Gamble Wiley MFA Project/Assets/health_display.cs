using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_display : MonoBehaviour
{
    private GameObject player;
    public int health;
    public Sprite[] health_array;
    public Image health_display_image;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<StatusManager>().playerHealth.health - 1;
        health_display_image.sprite = health_array[health];
    }
}
