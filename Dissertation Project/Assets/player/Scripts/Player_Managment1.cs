using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Managment1 : MonoBehaviour
{
    Inputs1 inputs;
    public Transform spawn;

    public int HP;

    private void Awake()
    {
        inputs = GetComponent<Inputs1>();
        spawn = GameObject.FindGameObjectWithTag("SpawnP2").transform;
        HP = 100;
    }

    private void Update()
    {
        inputs.HandleAllInputs();
        if(HP <= 0)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = spawn.position;
            HP = 100;
        }
        else
        {
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
