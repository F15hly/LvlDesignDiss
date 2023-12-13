using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Managment : MonoBehaviour
{
    Inputs inputs;
    Movement movement;
    Transform spawn;

    public int HP;

    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        movement = GetComponent<Movement>();
        HP = 100;
    }

    private void Update()
    {
        inputs.HandleAllInputs();
        if(HP <= 0)
        {
            transform.position = spawn.position;
            HP = 100;
        }
    }
}
