using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_script : MonoBehaviour
{
    public Text paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape") == true && Time.timeScale != 0) { Pause_gameplay(); }
        else if(Input.GetKeyDown("escape") == true && Time.timeScale == 0) { Resume_gameplay(); }
    }
    void Pause_gameplay()
    {
        Time.timeScale = 0;
        paused.enabled = true;
    }
    void Resume_gameplay()
    {
        Time.timeScale = 1;
        paused.enabled = false;
    }
}
