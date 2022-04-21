using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForPlayerNearSlots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public BoxCollider2D slotProx;
    public Text gamblePrompt;

    void OnTriggerEnter2D(Collider2D collision)
    {
        gamblePrompt.text = "Feeling lucky? Press 'enter' to gamble!";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        gamblePrompt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
