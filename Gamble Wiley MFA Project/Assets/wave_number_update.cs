using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave_number_update : MonoBehaviour
{

    private GameObject wave_manager;
    public int wave_number;
    public Sprite[] wave_array;
    public Image wave_display;

    // Start is called before the first frame update
    void Start()
    {
        wave_manager = GameObject.FindGameObjectWithTag("Modifier Manager");
        wave_number = wave_manager.GetComponent<wave_manager>().Current_Wave - 1;
        wave_display.sprite = wave_array[wave_number];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
