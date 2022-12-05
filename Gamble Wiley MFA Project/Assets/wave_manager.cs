using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is used to control the start and end of waves, keep track of the player's coins, and keep track of any current modifiers rolled when gambling.

public class wave_manager : MonoBehaviour
{
    //Wave_Starting as a variable might be useless, I think the way I've coded it we might be able to remove it outright but I'll have to test that
    public int Current_Wave = 1;
    private int Wave_Started = 1;
    public int Enemies;
    public int Coins;
    public int Coins_on_ground;
    private static GameObject instance;
    public GameObject victory_screen;

    // Start is called before the first frame update
    void Start()
    {
        //checks to see if there's already one of these loaded
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    public void EndWave()
    {
        //will clear current modifiers, increase the current wave number, then load the gambling scene
        if(Current_Wave == 10) //wave 10 is the final wave, so when all the enemies are defeated during the final wave the game should end
        {
            victory_screen = GameObject.FindGameObjectWithTag("victory");
            victory_screen.GetComponent<victory>().End_Game();
            return;
        }
        Current_Wave++;
        this.gameObject.GetComponent<modifiers>().Reset_modifiers();
        Debug.Log("Wave Ended!");
        SceneManager.LoadScene("Gamble scene");
    }

    public void StartWave()
    {
        //Loads the Game Scene
        //Game Scene spawns enemies on Start() equal to this script's wave number
        //will apply current modifiers to players and enemies
        SceneManager.LoadScene("PrototypeScene");
        Debug.Log(Wave_Started);
        Wave_Started = 1;
    }

    public void UpdateCoins(int x)
    {
        //changes the current coin amount. called by other scripts to update coin amount
        Coins += x;
    }

    public void EnemyCheck()
    {
        if (Wave_Started == 1)
        {
            //if a wave is currently running, it will check if there are no coins or enemies left, and when there aren't it ends the wave
            if (Enemies == 0 && Coins_on_ground == 0)
            {
                Wave_Started = 0;
                Debug.Log("Zero enemies!");
                EndWave();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //updates its count of how many enemies and coins are currently spawned, then runs EnemyCheck().
        Enemies = (GameObject.FindGameObjectsWithTag("Enemy").Length);
        Coins_on_ground = (GameObject.FindGameObjectsWithTag("Coin").Length);
        EnemyCheck();
    }
}
