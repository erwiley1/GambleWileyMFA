using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour
{
    public Text victory_text;
    public Button reset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End_Game()
    {
        Time.timeScale = 0;
        victory_text.enabled = true;
        reset.gameObject.SetActive(true);
    }
}