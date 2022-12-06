using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_clicked() { animator.SetBool("clicked", true); }
    public void Start_the_game()
    {
        SceneManager.LoadScene(1);
    }    
}
