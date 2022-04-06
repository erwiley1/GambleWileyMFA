using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Patterns
{
    public Sprite[] image = new Sprite[3];
    Vector3 placeHolder;
    public int coin;
    public Patterns(Sprite[] spirt)
    {

        int random = Random.Range(0, 1001);
        if (random == 1) { placeHolder = new Vector3(0, 0, 0); coin = 1000; }
        else if (random >= 2 && random <= 50) { placeHolder = new Vector3(1, 1, 1); coin = 500; }
        else if (random >= 51 && random <= 100) { placeHolder = new Vector3(2, 2, 2); coin = 125; }
        else if (random >= 101 && random <= 250) { placeHolder = new Vector3(3, 3, 3); coin = 100; }
        else if (random >= 251 && random <= 400) { placeHolder = new Vector3(4, 4, 4); coin = 50; }
        else if (random >= 401 && random <= 450) { placeHolder = new Vector3(1, 2, 1); coin = 0; }
        else if (random >= 451 && random <= 500) { placeHolder = new Vector3(4, 2, 3); coin = 0; }
        else if (random >= 501 && random <= 550) { placeHolder = new Vector3(1, 2, 3); coin = 0; }
        else if (random >= 551 && random <= 600) { placeHolder = new Vector3(3, 2, 3); coin = 0; }
        else if (random >= 601 && random <= 650) { placeHolder = new Vector3(2, 2, 3); coin = 0; }
        else if (random >= 651 && random <= 700) { placeHolder = new Vector3(1, 4, 3); coin = 0; }
        else if (random >= 701 && random <= 750) { placeHolder = new Vector3(2, 3, 4); coin = 0; }
        else if (random >= 751 && random <= 800) { placeHolder = new Vector3(3, 3, 4); coin = 0; }
        else if (random >= 801 && random <= 850) { placeHolder = new Vector3(3, 4, 1); coin = 0; }
        else if (random >= 851 && random <= 900) { placeHolder = new Vector3(4, 2, 4); coin = 0; }
        else if (random >= 901 && random <= 950) { placeHolder = new Vector3(4, 3, 4); coin = 0; }
        else if (random >= 951 && random <= 1000) { placeHolder = new Vector3(2, 3, 2); coin = 0; }
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
    public void roll()
    {
        if (!IsSpin)
        {
            if (Coins < 10)
            {
                return;
            }
            Coins -= 10;
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
