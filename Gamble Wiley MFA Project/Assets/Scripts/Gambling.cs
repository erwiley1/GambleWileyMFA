using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements; might be superfluous in this script if it only contains information about, and methods using, the Gamble variants
using GambleVariants;

/* What I want this script to do:
 * -attach to the slot machine object in the gambling area
 * -using the GambleVariant namespace & class, declare all possible gambles
 * -allow the player to interact with the slot machine to open the gambling interface
 * -upon entering the interface, the slot machine choose a random gamble and tells the player what's at stake
 * -player can choose not to gamble, in which case the machine will retain the current gamble
 * -if player chooses to gamble, their score is decreased by the appropriate amount and a random number is generated
 * -generated number is checked against different ranges of values to determine outcome of gambling
 * -player is told outcome of their gambling and appropriate changes are applied
 * -new gamble chosen at random and player is told what's at stake
 * -return to line 11, repeat gambling cycle until player leaves the area and heads to the next level
 */

public class Gambling : MonoBehaviour
{
    GambleVariant EmptyVariant = new GambleVariant();
    GambleVariant MoveSpeedMinor = new GambleVariant("25% chance to increase your speed by 20%.\n30% chance to reduce your speed by 10%.\nContinue?", 0.2, 25, 0.1, 30, 0, 0, 0, 0);
    GambleVariant RandGenGamble;
    public Text TalkToPlayer;
    private bool NeedToGetGamble;

    GambleVariant GetGamble()
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

    private void Start()
    {
        TalkToPlayer.text = "Press 'enter' to get a gamble!\n \nPress 'escape' if you're a coward.";
    }

    private void Update()
    {
       //  if( && )
        {

        }
    }
}