using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements; might be superfluous in this script if it only contains information about, and methods using, the Gamble variants


public class GambleVariant : MonoBehaviour
{
    // default constructor
    public GambleVariant()
    {
        _posMod = 0;
        _negMod = 0;
        _expositoryText = "No gamble selected";
        _negChanceMax = 0;
        _posChanceMin = 101;
        _jackpotMod = 0;
        _bankruptMod = 0;
        _bankruptChanceMax = 0;
        _jackpotChanceMin = 101;
    }

    // constructor for normal Gambles, which contain only standard positive and negative modifiers
    public GambleVariant(float posMod, float negMod, string expText, int negMax, int posMin)
    {
        _posMod = posMod;
        _negMod = negMod;
        _expositoryText = expText;
        _negChanceMax = negMax;
        _posChanceMin = posMin;
        _jackpotMod = 0;
        _bankruptMod = 0;
        _bankruptChanceMax = 0;
        _jackpotChanceMin = 101;
    }

    // constructor for Gambles with only one of either a bankrupt mod or a jackpot mod
    public GambleVariant(float posMod, float negMod, string expText, int negMax, int posMin, float bigMod, int bigModChance, bool isJack)
    {
        _posMod = posMod;
        _negMod = negMod;
        _expositoryText = expText;
        _negChanceMax = negMax;
        _posChanceMin = posMin;
        if (isJack)
        {
            _jackpotMod = bigMod;
            _bankruptMod = 0;
            _bankruptChanceMax = 0;
            _jackpotChanceMin = bigModChance;
        }
        else
        {
            _jackpotMod = 0;
            _bankruptMod = bigMod;
            _bankruptChanceMax = bigModChance;
            _jackpotChanceMin = 101;
        }
    }

    // constructor for Gambles with both a bankrupt mod and a jackpot mod
    public GambleVariant(float posMod, float negMod, string expText, int negMax, int posMin, float jackMod, int jackMin, float bankMod, int bankMax)
    {
        _posMod = posMod;
        _negMod = negMod;
        _expositoryText = expText;
        _negChanceMax = negMax;
        _posChanceMin = posMin;
        _jackpotMod = jackMod;
        _bankruptMod = bankMod;
        _bankruptChanceMax = bankMax;
        _jackpotChanceMin = jackMin;
    }

    // now defining the different messages that can output when a Gamble is made and the result is determined
    public string neutralRoll = "No bonus here. Guess it coulda been worse.";
    public string posRoll = "The odds are in your favor!";
    public string negRoll = "Bad luck, buddy!";
    public string jackRoll = "YOU HIT THE JACKPOT!!!";
    public string bankRoll = "LOOKS LIKE YOU'RE BANKRUPT!!!";

    public string outMessageTemplate;
    
    // I know I need some sort of function that rolls a random number, idk what the best way to optimize it is
    public int RollSlots() // rolls a random integer, checks it against possible ranges of values, outputs an integer that determines the result
    {
        int roll = Random.Range(1, 100);
        
        if(roll <= _bankruptChanceMax)
        {
            outMessageTemplate = bankRoll;
            _getResult = 1;
        }
        if(roll <= _negChanceMax && roll > _bankruptChanceMax)
        {
            outMessageTemplate = negRoll;
            _getResult = 2;
        }
        if(roll <= _posChanceMin && roll > _negChanceMax)
        {
            outMessageTemplate = neutralRoll;
            _getResult = 3;
        }
        if(roll <= _jackpotChanceMin && roll > _posChanceMin)
        {
            outMessageTemplate = posRoll;
            _getResult = 4;
        }
        if(roll > _jackpotChanceMin)
        {
            outMessageTemplate = jackRoll;
            _getResult = 5;
        }

        return _getResult;
    }
    
    // private values only used within the class or its methods
    private string _expositoryText;
    private float _posMod;
    private float _negMod;
    private int _negChanceMax;
    private int _posChanceMin;
    // some gambles will have a hidden 'jackpot' and/or 'bankrupt' modifier for rolling high or low enough 
    private float _jackpotMod;
    private float _bankruptMod;
    private int _bankruptChanceMax;
    private int _jackpotChanceMin;
    // getResult is used only in RollSlots(), default value in all constructors is 0
    private int _getResult;
}
