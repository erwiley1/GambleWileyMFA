using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script attaches to every coin object. It holds a value that can be changed in the inspector so multiple coins containing the same value or different ones can be made quickly.
// Upon the player touching the coin's trigger collider, the value stored in the DisplayScore script, named 'theScore,' is increased by coinVal, and the coin is destroyed ('collected').

public class CoinScore : MonoBehaviour
{
    public int coinVal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisplayScore.theScore += coinVal;
        Destroy(gameObject);
    }
}