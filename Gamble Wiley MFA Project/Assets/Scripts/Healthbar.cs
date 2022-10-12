using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth; 
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth;
    }

    
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth;
    }
}
