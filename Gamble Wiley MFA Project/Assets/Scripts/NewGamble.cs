using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Alex's note: this code was completely uncommentated when I got here so some of this code I'm not exactly sure what it does but it works so I'm not touching it if I don't have to
public class Patterns
{
    public GameObject modifiers;
    //figures out the result of gambling, displays it visually
    public Sprite[] image = new Sprite[3];
    Vector3 placeHolder;
    public int coin;

    private void Start() //this start doesnt call on start because /shrug so i called it during the rolling process
    {
        modifiers = GameObject.FindGameObjectWithTag("Modifier Manager");
        Debug.Log("Modifiers found! - NewGamble");
    }

    public Patterns(Sprite[] spirt)
    {
        //to add a new result, add it as a function on modifiers and call it during the roll's result
        Start();
        int random = Random.Range(1, 1001); // (1, 1001) for all results, (1,1) and change the (1) result to test a specific outcome
        if (random >= 1 && random <= 166) { placeHolder = new Vector3(0, 0, 0); modifiers.GetComponent<modifiers>().Increase_player_damage(); }
        else if (random >= 167 && random <= 332) { placeHolder = new Vector3(1, 1, 1); modifiers.GetComponent<modifiers>().Increase_player_speed(); }
        else if (random >= 333 && random <= 498) { placeHolder = new Vector3(2, 2, 2); modifiers.GetComponent<modifiers>().Increase_player_attack_speed(); }
        else if (random >= 499 && random <= 664) { placeHolder = new Vector3(3, 3, 3); modifiers.GetComponent<modifiers>().Increase_enemy_damage(); }
        else if (random >= 665 && random <= 830) { placeHolder = new Vector3(4, 4, 4); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        else if (random >= 831 && random <= 1000) { placeHolder = new Vector3(1, 2, 1); modifiers.GetComponent<modifiers>().Increase_enemy_attack_speed(); }
        //else if (random >= 997 && random <= 1000) { placeHolder = new Vector3(4, 2, 3); modifiers.GetComponent<modifiers>().Increase_player_damage(); }
        //else if (random >= 501 && random <= 550) { placeHolder = new Vector3(1, 2, 3); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 551 && random <= 600) { placeHolder = new Vector3(3, 2, 3); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 601 && random <= 650) { placeHolder = new Vector3(2, 2, 3); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 651 && random <= 700) { placeHolder = new Vector3(1, 4, 3); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 701 && random <= 750) { placeHolder = new Vector3(2, 3, 4); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 751 && random <= 800) { placeHolder = new Vector3(3, 3, 4); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 801 && random <= 850) { placeHolder = new Vector3(3, 4, 1); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 851 && random <= 900) { placeHolder = new Vector3(4, 2, 4); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 901 && random <= 950) { placeHolder = new Vector3(4, 3, 4); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        //else if (random >= 951 && random <= 1000) { placeHolder = new Vector3(2, 3, 2); modifiers.GetComponent<modifiers>().Increase_enemy_speed(); }
        for (int i = 0; i < 3; i++)
        {
            image[i] = spirt[(int)placeHolder[i]];
        }
    }
}
public class NewGamble : MonoBehaviour
{
    public Text CoinText;
    public int Coins;
    public Image[] slots;
    public Sprite[] image;
    private bool IsSpin = false;
    private bool Spinning = false;
    Patterns pat;
    private GameObject WaveManager;
    public void roll()
    {
        if (!IsSpin)
            //checks if its already spinning
        {
            if (Coins < 10)
            {
                //aborts if you don't have enough coins
                return;
            }
            Coins -= 10; //updates coins locally
            WaveManager.GetComponent<wave_manager>().UpdateCoins(-10); //updates coins on wave_manager
            CoinText.text = Coins.ToString();
            pat = new Patterns(image);
            IsSpin = true;
            Spinning = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = Coins.ToString();
        WaveManager = GameObject.FindGameObjectWithTag("Modifier Manager");
        Coins = WaveManager.GetComponent<wave_manager>().Coins;
        CoinText.text = Coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpin)
        {
            foreach (var item in slots)
            {
                item.sprite = image[Random.Range(0, image.Length)];
            }

            if (Spinning)
            {
                StartCoroutine(Magic());
            }
            Spinning = false;
        }

    }

    IEnumerator Magic()
    {
        yield return new WaitForSeconds(3);
        IsSpin = false;
        for (int i = 0; i < 3; i++)
        {
            slots[i].sprite = pat.image[i];
        }
        Coins += pat.coin;
        CoinText.text = Coins.ToString();

    }
}
