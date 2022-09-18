using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script attaches to every coin object. It holds a value that can be changed in the inspector so multiple coins containing the same value or different ones can be made quickly.
// Upon the player touching the coin's trigger collider, the value stored in the wave_manager script, named 'Coins,' is increased by coinVal, and the coin is destroyed ('collected').



public class CoinScore : MonoBehaviour
{
    public int coinVal;
    private GameObject WaveManager;

    void Awake()
    {
        WaveManager = GameObject.FindGameObjectWithTag("Modifier Manager"); //finds the wave manager
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WaveManager.GetComponent<wave_manager>().UpdateCoins(coinVal); //updates coins on wave manager
            Destroy(gameObject);
        }
    }
}