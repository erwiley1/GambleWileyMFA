using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script attaches to the player, and stores values for the player's current health and max health
// and contains functions that allow other scripts to read and/or modify these values as seen fit.

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    // functions used for UI
    public float getCurrentHealth()
    {
        return health;
    }

    public float getCurrentMaxHealth()
    {
        return maxHealth;
    }

    // function used by Gambling mechanics
    public void ModMaxHealth(float healthMod)
    {
        maxHealth = +healthMod;
        UpdateHealth(0f); // if player's max health falls below 0, then the player is going to be dead
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player Death");
        }
    }
}
