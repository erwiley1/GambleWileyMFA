using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script attaches to the UI element that displays the score, and also stores the current value for the score (which other scripts modify)

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;
    public static int theScore;
    
    void Update()
    {
        scoreText.text = "Score: " + theScore;
    }
}