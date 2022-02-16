using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForPlayerNearSlots : MonoBehaviour
{

    public BoxCollider2D slotProx; // Collision trigger will prompt player to gamble when near slot machine object
    public Text gamblePrompt; // floating text box, wil be empty when not near slot machine, will show prompt when near slot machine
    public GameObject SlotsInterface; // UI and contained script for gambling
    public GameObject SlotMachine; // will be disabled last
    bool inTrigger;

    void OnTriggerEnter2D()
    {
        gamblePrompt.text = "Feeling lucky? Press 'enter' to gamble!";
        inTrigger = true;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && inTrigger)
        {
            gamblePrompt.text = "";
            SlotsInterface.SetActive(true);
            SlotMachine.SetActive(false);
        }
    }

    void OnTriggerExit2D()
    {
        gamblePrompt.text = "";
        inTrigger = false;
    }
    
}
