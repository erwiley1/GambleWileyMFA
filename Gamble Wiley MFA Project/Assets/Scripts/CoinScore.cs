using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public int coinVal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisplayScore.theScore += coinVal;
        Destroy(gameObject);
    }
}