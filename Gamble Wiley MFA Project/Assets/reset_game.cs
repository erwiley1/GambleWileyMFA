using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reset_game : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            GetComponent<Text>().enabled = true; 
        }
        if (GetComponent<Text>().enabled && Input.anyKeyDown)
        {
            Destroy(GameObject.FindGameObjectWithTag("Modifier Manager"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
