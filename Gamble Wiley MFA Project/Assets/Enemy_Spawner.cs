using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to an object in the Game Scene and spawns enemies on Start(), which should be called every time we load from the gambling scene to the game scene

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject Wave_Manager;
    public int Current_Wave; 
    public GameObject Grunt;

    // Start is called before the first frame update
    void Start()
    {
        Wave_Manager = GameObject.FindGameObjectWithTag("Modifier Manager");
        Current_Wave = Wave_Manager.GetComponent<wave_manager>().Current_Wave;
        Debug.Log(Current_Wave);
        for (int i = 0; i < Current_Wave; i++)
        {
            Debug.Log("Spawning Enemy!");
            Instantiate(Grunt, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        }
    }
}
