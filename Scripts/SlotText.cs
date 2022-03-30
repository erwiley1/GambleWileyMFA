using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements

public class SlotText : MonoBehaviour
{

    char[] numberRand = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // will attach to slotNum in Update()
    public Text slotNum;
    public float time; // time to delay stopping Text Left Mid and Right
    
    // Update is called once per frame
    void Update()
    {
        slotNum.text = numberRand[Random.Range(0, numberRand.Length)].ToString();
        /* Every frame after you click start and until you click stop, 
           one of the characters in the range of the array for numberRand will be chosen at random, 
           converted to a string value, and be stored in the text of slotNum. */
    }
    
    public void OffEnable()
    {
        Invoke("DelayNum", time);
        // invokes the DelayNum function below after <time> seconds have passed
    }
    public void OnEnable() // enables Update() so that slotNum generates a new random value every frame
    {
        enabled = true; 
    }

    void DelayNum() // disables Update() so that slotNum stops generating new random values
    {
        enabled = false;
    }
}
