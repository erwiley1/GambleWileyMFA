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

    void OnTriggerEnter2D(Collider2D collision)
    {
        gamblePrompt.text = "Feeling lucky? Press 'enter' to gamble!";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        gamblePrompt.text = "";
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("enter"))
        {
            gamblePrompt.text = "";
            SlotsInterface.SetActive(true);
            SlotMachine.SetActive(false);
        }
    }
}
