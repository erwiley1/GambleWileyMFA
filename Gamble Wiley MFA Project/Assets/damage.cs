using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    private GameObject modifiers; // used for modifier application
    public int attack_damage; //used to determine how much damage the attacks do
    
    // Start is called before the first frame update
    void Start()
    {
        attack_damage = 1; //for some reason i was experiencing a bug where these guys instantiated with 0 attack damage and attack speed and this fixed it
        Debug.Log(attack_damage);
        modifiers = GameObject.FindGameObjectWithTag("Modifier Manager");
        attack_damage *= modifiers.GetComponent<modifiers>().current_enemy_damage;
        Debug.Log(attack_damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
