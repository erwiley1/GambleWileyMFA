using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements

public class Slots : MonoBehaviour
{
    char[] numberRand = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // attaches to slotNum (below)
    public Text slotNum;
    public float time; // time to delay stopping Text Left Mid and Right
    
    // Update is called once per frame
    void Update()
    {
        slotNum.text = numberRand[Random.Range(0, numberRand.Length)].ToString();
        // Every frame after you click start and until you click stop, 
        // one of the characters in the range of the array for numberRand will be chosen at random, converted to a string value, and be stored in the text of slotNum.
    }

    public void OffEnable()
    {
        Invoke("DelayNum", time); // invokes the DelayNum function below after a number of seconds equal to time have passed
    }
    public void OnEnable()
    {
        enabled = true; 
    }

    void DelayNum()
    {
        enabled = false;
    }
}
