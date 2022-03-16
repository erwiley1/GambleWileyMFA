using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;
    public static int theScore;
    
    void Update()
    {
        scoreText.text = "Score: " + theScore;
    }
}