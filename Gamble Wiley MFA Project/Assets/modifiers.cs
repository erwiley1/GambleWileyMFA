using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifiers : MonoBehaviour
{
    public int default_speed = 1;
    public int current_speed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void double_enemy_speed()
    {
        current_speed = 2;
    }

    public void reset_modifiers()
    {
        current_speed = default_speed;
    }
}
