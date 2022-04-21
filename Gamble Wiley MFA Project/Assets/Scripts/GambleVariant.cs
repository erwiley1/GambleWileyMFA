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
            _outMod = 0;
            _modTarget = "Nothing targeted for modification.";
        }

        // constructor that takes all arguments
        public GambleVariant(string expText, double posMod, int posChance, double negMod, int negChance, double jackMod, int jackChance, double bankMod, int bankChance, string modTarget)
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
            _outMod = 0;
            _modTarget = modTarget;
        }
        /* The parameters for a GambleVariant include the chances to roll the respective modifiers,
         * but the private variables within the class act as difficulty checks (DCs) for RollSlots() below, as calculated when the class is initialized.
         * When rolling, the player loses ties. It is impossible to roll lower than 1, and it is impossible to roll higher than 100.
         */
        
        // I know I need some sort of function that rolls a random number, idk what the best way to optimize it is
        public void RollSlots()
        {
            int roll = Random.Range(1, 100);

            if (roll <= 0 || roll > 100)
            {
                _outMessage = "Error: rolled a value not within range.";
                _outMod = 0;
                _getResult = 0;
            }
            else if (roll <= _bankChanceMax && roll > 0) // Remember, the player loses ties; the chance value is the number to beat
            {
                _outMessage = _bankRoll;
                _outMod = _bankMod;
                _getResult = 1;
            }
            else if (roll <= _negChanceMax && roll > _bankChanceMax) // the function keeps counting up until it figures out which number it's beaten
            {
                _outMessage = _negRoll;
                _outMod = _negMod;
                _getResult = 2;
            }
            else if (roll <= _posChanceMin && roll > _negChanceMax)
            {
                _outMessage = _neutralRoll;
                _outMod = 0;
                _getResult = 3;
            }
            else if (roll <= _jackChanceMin && roll > _posChanceMin)
            {
                _outMessage = _posRoll;
                _outMod = _posMod;
                _getResult = 4;
            }
            else if (roll <= 100 && roll > _jackChanceMin)
            {
                _outMessage = _jackRoll;
                _outMod = _jackMod;
                _getResult = 5;
            }
        }

        // accessors
        public double OutMod() { return _outMod; }
        public string OutMessage() { return _outMessage; }
        public int ResultGet() { return _getResult; }
        public string Exposition() { return _expText; }
        public string ModTarget() { return _modTarget; }

        // private variables
        private string _expText;
        private double _posMod;
        private double _negMod;
        private int _negChanceMax;
        private int _posChanceMin;
        private double _jackMod;
        private double _bankMod;
        private int _bankChanceMax;
        private int _jackChanceMin;
        private int _getResult;
        private double _outMod;
        private string _neutralRoll = "No change here. Guess it coulda been worse.";
        private string _posRoll = "The odds are in your favor!";
        private string _negRoll = "Bad luck, buddy!";
        private string _jackRoll = "YOU HIT THE JACKPOT!!!";
        private string _bankRoll = "LOOKS LIKE YOU'RE BANKRUPT!!!";
        private string _outMessage;
        private string _modTarget;
    }
}