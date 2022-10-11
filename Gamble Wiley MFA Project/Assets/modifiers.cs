using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifiers : MonoBehaviour
{
    //default is never changed in the scripts, current changes when the modifier should be applied
    public int default_enemy_speed = 1;
    public int current_enemy_speed = 1;

    public int default_enemy_damage = 1;
    public int current_enemy_damage = 1;

    public int default_enemy_attack_speed = 1;
    public int current_enemy_attack_speed = 1;

    public int default_player_speed = 1;
    public int current_player_speed = 1;

    public int default_player_attack_speed = 1;
    public int current_player_attack_speed = 1;

    public int default_player_damage = 1;
    public int current_player_damage = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //modifiers are in the same order as above
    public void Increase_enemy_speed()
    {
        if(current_enemy_speed < 5)
        {
            current_enemy_speed++;
        }
        Debug.Log("Enemy Speed Increased!");
    }
    public void Increase_enemy_damage()
    {
        if (current_enemy_damage < 5)
        {
            current_enemy_damage++;
        }
        Debug.Log("Enemy Damage Increased!");
    }
    public void Increase_enemy_attack_speed()
    {
        if (current_enemy_attack_speed < 5)
        {
            current_enemy_attack_speed++;
        }
        Debug.Log("Enemy Attack Speed Increased!");
    }
    public void Increase_player_speed()
    {
        if (current_player_speed < 3)
        {
            current_player_speed++;
        }
        Debug.Log("Player Speed Increased!");
    }
    public void Increase_player_damage()
    {
        if (current_player_damage < 3)
        {
            current_player_damage++;
        }
        Debug.Log("Player Damage Increased!");
    }
    public void Increase_player_attack_speed()
    {
        if (current_player_attack_speed < 3)
        {
            current_player_attack_speed++;
        }
        Debug.Log("Player Attack Speed Increased!");
    }

    public void Reset_modifiers() //resests all modifiers back to their default state, is called by wave manager on round end
    {
        current_enemy_speed = default_enemy_speed;
        current_enemy_damage = default_enemy_damage;
        current_enemy_attack_speed = default_enemy_attack_speed;
        
        current_player_speed = default_player_speed;
        current_player_damage = default_player_damage;
        current_player_attack_speed = default_player_attack_speed;
    }
}
