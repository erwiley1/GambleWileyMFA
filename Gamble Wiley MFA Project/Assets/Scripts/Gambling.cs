using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GambleVariants;

/* What I want this script to do:
 * -using the GambleVariant namespace & class, declare all possible gambles
 * -allow the player to interact with the slot machine to open the gambling interface
 * -upon entering the interface, the slot machine chooses a random gamble and tells the player what's at stake
 * -player can choose not to gamble, in which case the machine will retain the current gamble
 * -if player chooses to gamble, their score/money is decreased by the appropriate amount and a random number is generated
 * -generated number is checked against different ranges of values to determine outcome of gambling
 * -player is told outcome of their gambling and appropriate changes are applied
 * -new gamble chosen at random and player is told what's at stake
 * -repeat gambling cycle until player leaves the area and heads to the next level
 */

public class Gambling : MonoBehaviour
{
    public Text InitialPlayerPrompt;
    public Text GamblingPromptsInUI;
    public BoxCollider2D slotProx;
    public GameObject SlotsUI;
    public GameObject SlotMachine;
    public GameObject Player;

    // When the scene starts, we haven't generated a gamble yet and the interface is not open
    private void Start()
    {
        NeedToGetGamble = true;
        InterfaceIsOpen = false;
        RandGenGamble = EmptyVariant;
    }

    void OnTriggerEnter2D()
    {
        InitialPlayerPrompt.text = "Feeling lucky? Press 'enter' to gamble!";
        inTrigger = true;
    }

    void Update()
    {
        // When the player moves next to the slot machine and presses the enter key, we stop prompting them to open gambling, and then turn on the gambling interface
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && inTrigger && InterfaceIsOpen == false)
        {
            OpenSlotUI();
        }

        // When the player needs to get a gamble, we allow them to press enter to do so, then tell them which gamble they got
        if (NeedToGetGamble == true && InterfaceIsOpen == true && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            GetGamble();
            NeedToGetGamble = false;
            GamblingPromptsInUI.text = RandGenGamble.Exposition() + "\n \nPress 'enter' to try your luck! Or press 'escape' if you're a big chicken.";
        }

        // When the player has the UI open, has generated a gamble, and presses enter to try their luck, we run RollSlots()
        if (NeedToGetGamble == false && InterfaceIsOpen == true && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            RandGenGamble.RollSlots();
            switch (RandGenGamble.ResultGet())
            {
                case 1:
                case 2:
                    GamblingPromptsInUI.text = RandGenGamble.OutMessage() + "\n \n" + RandGenGamble.ModTarget() + " reduced by " + 
                        (int)(RandGenGamble.OutMod() * 100) + "%.\n \n Press 'enter' to get a new gamble, or 'escape' to quit while you're ahead.";
                    break;
                case 3:
                    GamblingPromptsInUI.text = RandGenGamble.OutMessage() + "\n \n Press 'enter' to get a new gamble, or 'escape' to quit while you're ahead.";
                    break;
                case 4:
                case 5:
                    GamblingPromptsInUI.text = RandGenGamble.OutMessage() + "\n \n" + RandGenGamble.ModTarget() + " increased by " +
                        (int)(RandGenGamble.OutMod() * 100) + "%.\n \n Press 'enter' to get a new gamble, or 'escape' to quit while you're ahead.";
                    break;

                default:
                    GamblingPromptsInUI.text = RandGenGamble.OutMessage() + "\n \n Press 'enter' to get a new gamble, or 'escape' to quit while you're ahead.";
                    break;
            }

            NeedToGetGamble = true;

            if (RandGenGamble.ModTarget() == "Player movement speed")
            {
                switch (RandGenGamble.ResultGet())
                {
                    case 1:
                    case 2:
                        Player.GetComponent<PlayerMovement>().moveSpeedMod -= (float)RandGenGamble.OutMod();
                        break;
                    case 3:
                        break;
                    case 4:
                    case 5:
                        Player.GetComponent<PlayerMovement>().moveSpeedMod += (float)RandGenGamble.OutMod();
                        break;

                    default:
                        break;
                }
            }
        }

        // Option for the player to back out at any time
        if (Input.GetKeyDown(KeyCode.Escape) && InterfaceIsOpen == true)
        {
            SlotsUI.SetActive(false);
            InterfaceIsOpen = false;
        }        
    }

    void OnTriggerExit2D()
    {
        InitialPlayerPrompt.text = "";
        inTrigger = false;
    }

    // Making methods that can use the WaitForSeconds function (need help debugging)
    private void OpenSlotUI()
    {
        // yield return new WaitWhile(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter));
        InitialPlayerPrompt.text = "";
        SlotsUI.SetActive(true);
        InterfaceIsOpen = true;
        // checking for whether player has already generated a gamble in this scene
        if (NeedToGetGamble == true)
        {
            GamblingPromptsInUI.text = "Press 'enter' to get a gamble!\n \nPress 'escape' to exit gambling, syou coward.";
        }
        if (NeedToGetGamble == false)
        {
            GamblingPromptsInUI.text = RandGenGamble.Exposition() + "Press 'enter' to try your luck! Or press 'escape' to wuss out again.";
        }
    }
    
    private GambleVariant GetGamble()
    {
        int gambleGet = Random.Range(1, 5);

        switch(gambleGet)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                RandGenGamble = MoveSpeedMinor;
                break;

            default:
                RandGenGamble = EmptyVariant;
                break;
        }

        return RandGenGamble;
    }
    
    // private variables
    private bool NeedToGetGamble;
    private bool InterfaceIsOpen;
    private bool inTrigger;
    private GambleVariant EmptyVariant = new GambleVariant();
    private GambleVariant MoveSpeedMinor = new GambleVariant("25% chance to increase your speed by 20%.\n30% chance to reduce your speed by 10%.", 0.2, 25, 0.1, 30, 0, 0, 0, 0, "Player movement speed");
    private GambleVariant RandGenGamble;

}