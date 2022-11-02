using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to an object in the Game Scene and spawns enemies on Start(), which should be called every time we load from the gambling scene to the game scene

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject Wave_Manager;
    public int Current_Wave; 
    public GameObject Grunt;
    public GameObject Triggerman;

    // Start is called before the first frame update
    void Start()
    {
        Wave_Manager = GameObject.FindGameObjectWithTag("Modifier Manager");
        Current_Wave = Wave_Manager.GetComponent<wave_manager>().Current_Wave;
        Debug.Log(Current_Wave);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < (Current_Wave * 5); i++)
        {
            Debug.Log("Spawning Grunt!");
            Instantiate(Grunt, new Vector3(5, 5, 0), Quaternion.identity);
            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
            yield return new WaitForSecondsRealtime(1); //adjust this number to alter the spawn delay in real time
        }
        if (Current_Wave >= 5)
        {
            for(int i = 0; i < ((Current_Wave -5) * 5); i++)
            {
                Debug.Log("Spawning Triggerman!");
                Instantiate(Triggerman, new Vector3(5, 5, 0), Quaternion.identity);
                Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
                yield return new WaitForSecondsRealtime(1); //adjust this number to alter the spawn delay in real time
            }
        }
    }
}
