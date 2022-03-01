using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GambleVariants
{
    public class GambleVariant
    {
        // default constructor that takes no arguments
        public GambleVariant()
        {
            _expText = "No information provided.";
            _posMod = 0;
            _posChanceMin = 100;
            _negMod = 0;
            _negChanceMax = 0;
            _jackMod = 0;
            _jackChanceMin = 100;
            _bankMod = 0;
            _bankChanceMax = 0;
            _getResult = 0;
        }

        // constructor that takes all arguments
        public GambleVariant(string expText, double posMod, int posChance, double negMod, int negChance, double jackMod, int jackChance, double bankMod, int bankChance)
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

       
        public string outMessage;

        // I know I need some sort of function that rolls a random number, idk what the best way to optimize it is
        public int RollSlots() // rolls a random integer, checks it against possible ranges of values, outputs an integer that determines the result
        {
            int roll = Random.Range(1, 100);

            if (roll <= 0 || roll > 100)
            {
                outMessage = "Error: rolled a value not within range.";
                _getResult = 0;
            }
            else if (roll <= _bankChanceMax && roll > 0) // Remember, the player loses ties; the chance value is the number to beat
            {
                outMessage = bankRoll;
                _getResult = 1;
            }
            else if (roll <= _negChanceMax && roll > _bankChanceMax) // the function keeps counting up until it figures out which number it's beaten
            {
                outMessage = negRoll;
                _getResult = 2;
            }
            else if (roll <= _posChanceMin && roll > _negChanceMax)
            {
                outMessage = neutralRoll;
                _getResult = 3;
            }
            else if (roll <= _jackChanceMin && roll > _posChanceMin)
            {
                outMessage = posRoll;
                _getResult = 4;
            }
            else if (roll <= 100 && roll > _jackChanceMin)
            {
                outMessage = jackRoll;
                _getResult = 5;
            }

            return _getResult;
        }

        public string Exposition()
        {
            return _expText;
        }

        // private values only used within the class or its methods
        private string _expText;
        private double _posMod;
        private double _negMod;
        private int _negChanceMax;
        private int _posChanceMin;
        // some gambles will have a hidden 'jackpot' and/or 'bankrupt' modifier for rolling high or low enough 
        private double _jackMod;
        private double _bankMod;
        private int _bankChanceMax;
        private int _jackChanceMin;
        // getResult is used only in RollSlots(), default value in constructors is 0
        private int _getResult;
        // now defining the different messages that can output when a Gamble is made and the result is determined
        private string neutralRoll = "No bonus here. Guess it coulda been worse.";
        private string posRoll = "The odds are in your favor!";
        private string negRoll = "Bad luck, buddy!";
        private string jackRoll = "YOU HIT THE JACKPOT!!!";
        private string bankRoll = "LOOKS LIKE YOU'RE BANKRUPT!!!";
    }
}