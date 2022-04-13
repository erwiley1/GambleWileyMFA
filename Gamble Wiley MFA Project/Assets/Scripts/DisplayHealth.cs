using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script attaches to the healthText UI element, and displays the player's current HP and current max HP

public class DisplayHealth : MonoBehaviour
{
    public Text healthText;
    public static float currentHealth;
    public static float currentMaxHealth;
    
    void Update()
    {
        // currentHealth = PlayerHealth.getCurrentHealth();
        // currentMaxHealth = PlayerHealth.getCurrentMaxHealth();
        healthText.text = "HP: " + currentHealth + " / " + currentMaxHealth;
    }
}
