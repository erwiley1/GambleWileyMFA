using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sounds : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound_player;
    public AudioClip[] audio_options;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("G_isAttack") == true)
        {
            sound_player.clip = audio_options[Random.Range(0,3)];
            sound_player.Play();
        }
    }
}
