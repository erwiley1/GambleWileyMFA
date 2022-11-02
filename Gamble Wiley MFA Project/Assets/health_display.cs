using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_display : MonoBehaviour
{
    private GameObject player;
    public int health;
    public Text number;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<StatusManager>().playerHealth.health;
        number.text = health.ToString();
    }
}
