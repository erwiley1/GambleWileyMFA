using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_number_update : MonoBehaviour
{

    private GameObject wave_manager;
    public int score;
    public Text number;

    // Start is called before the first frame update
    void Start()
    {
        wave_manager = GameObject.FindGameObjectWithTag("Modifier Manager");
    }

    // Update is called once per frame
    void Update()
    {
        score = wave_manager.GetComponent<wave_manager>().Coins;
        number.text = score.ToString();
    }
}
