using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
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
        if (animator.GetBool("isAttack")) 
        {
            sound_player.clip = audio_options[0];
            sound_player.Play();
        }
        if (animator.GetBool("tommygun_attack"))
        {
            sound_player.clip = audio_options[2];
            sound_player.Play();
        }
        if (animator.GetBool("shotgun_attack"))
        {
            sound_player.clip = audio_options[1];
            sound_player.Play();
        }
    }
}
