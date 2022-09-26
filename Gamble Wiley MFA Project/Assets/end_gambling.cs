using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_gambling : MonoBehaviour
{
    private GameObject WaveManager;
    void Awake()
    {
        WaveManager = GameObject.FindGameObjectWithTag("Modifier Manager"); //finds the wave manager
    }
    public void gambling_over()
    {
        WaveManager.GetComponent<wave_manager>().StartWave();
        Debug.Log("Starting Wave");
    }
}
