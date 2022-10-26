using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave_number_update : MonoBehaviour
{

    private GameObject wave_manager;
    public int wave_number;
    public Text number;

    // Start is called before the first frame update
    void Start()
    {
        wave_manager = GameObject.FindGameObjectWithTag("Modifier Manager");
        wave_number = wave_manager.GetComponent<wave_manager>().Current_Wave;
        number.text = wave_number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
