using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// note: add more Behaviours to this script as they are added to the Player

public class TogglePlayerBehavior : MonoBehaviour
{
    public GameObject SlotUI;
    public Behaviour PlayerMovement;
    void Update()
    {
        if(SlotUI.activeInHierarchy)
        {
            PlayerMovement.enabled = false;
        }
        else
        {
            PlayerMovement.enabled = true;
        }
    }
}
