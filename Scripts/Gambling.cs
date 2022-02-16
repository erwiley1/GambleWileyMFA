using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements; might be superfluous in this script if it only contains information about, and methods using, the Gamble variants

/* What I want this script to do:
 * -attach to the slot machine object in the gambling area
 * -create a template for potential gambles the player can make
 * -using the template, initialize all possible gambles
 * -allow the player to interact with the slot machine to open the gambling interface
 * -upon entering the interface, the slot machine choose a random gamble and tells the player what's at stake
 * -player can choose not to gamble, in which case the machine will retain the current gamble
 * -if player chooses to gamble, their score is decreased by the appropriate amount and a random number is generated
 * -generated number is checked against different ranges of values to determine outcome of gambling
 * -player is told outcome of their gambling and appropriate changes are applied
 * -new gamble chosen at random and player is told what's at stake
 * -return to line 11, repeat gambling cycle until player leaves the area and heads to the next level
 */

public class GambleVariant : MonoBehaviour
{
    // constructor
    public GambleVariant(string expText, float posMod, int posChance, float negMod, int negChance, float jackMod, int jackChance, float bankMod, int bankChance)
    {
        _expText = expText;
        _posMod = posMod;
        _negMod = negMod;
        _jackMod = jackMod;
        _bankMod = bankMod;
        _jackChanceMin = 100 - jackChance;
        _posChanceMin = _jackChanceMin - posChance;
        _bankChanceMax = bankChance;
        _negChanceMax = _bankChanceMax + negChance;
        _getResult = 0;
    }
    /* The parameters for a GambleVariant include the chances to roll the respective modifiers,
     * but the private variables within the class act as difficulty checks (DCs) for RollSlots() below, as calculated when the class is initialized.
     * When rolling, the player loses ties. It is impossible to roll lower than 1, and it is impossible to roll higher than 100.
     */

    // default constructor
    public GambleVariant()
    {
        _expText = "No gamble selected";
        _posMod = 0;
        _negMod = 0;
        _jackMod = 0;
        _bankMod = 0;
        _negChanceMax = 0;
        _posChanceMin = 100;
        _bankChanceMax = 0;
        _jackChanceMin = 100;
        _getResult = 0;
    }
    
    // now defining the different messages that can output when a Gamble is made and the result is determined
    public string neutralRoll = "No bonus here. Guess it coulda been worse.";
    public string posRoll = "The odds are in your favor!";
    public string negRoll = "Bad luck, buddy!";
    public string jackRoll = "YOU HIT THE JACKPOT!!!";
    public string bankRoll = "LOOKS LIKE YOU'RE BANKRUPT!!!";

    public string outMessage;
        
    // I know I need some sort of function that rolls a random number, idk what the best way to optimize it is
    public int RollSlots() // rolls a random integer, checks it against possible ranges of values, outputs an integer that determines the result
    {
        int roll = Random.Range(1, 100);
        
        if(roll <= 0 || roll > 100)
        {
            outMessage = "Error: rolled a value not within range.";
            _getResult = 0;
        }
        else if(roll <= _bankChanceMax && roll > 0) // Remember, the player loses ties; the chance value is the number to beat
        {
            outMessage = bankRoll;
            _getResult = 1;
        }
        else if(roll <= _negChanceMax && roll > _bankChanceMax) // the function keeps counting up until it figures out which number it's beaten
        {
            outMessage = negRoll;
            _getResult = 2;
        }
        else if(roll <= _posChanceMin && roll > _negChanceMax)
        {
            outMessage = neutralRoll;
            _getResult = 3;
        }
        else if(roll <= _jackChanceMin && roll > _posChanceMin)
        {
            outMessage = posRoll;
            _getResult = 4;
        }
        else if(roll <= 100 && roll > _jackChanceMin)
        {
            outMessage = jackRoll;
            _getResult = 5;
        }

        return _getResult;
    }
    
    // private values only used within the class or its methods
    private string _expText;
    private float _posMod;
    private float _negMod;
    private int _negChanceMax;
    private int _posChanceMin;
    // some gambles will have a hidden 'jackpot' and/or 'bankrupt' modifier for rolling high or low enough 
    private float _jackMod;
    private float _bankMod;
    private int _bankChanceMax;
    private int _jackChanceMin;
    // getResult is used only in RollSlots(), default value in all constructors is 0
    private int _getResult;
}

public class Gambling : MonoBehaviour
{
    private void Update()
    {
        
    }
}