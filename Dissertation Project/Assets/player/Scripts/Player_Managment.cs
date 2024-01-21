﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Managment : MonoBehaviour
{
    Inputs inputs;
    public Transform spawn;
    public TextMeshProUGUI HPText;

    public int HP;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        spawn = GameObject.FindGameObjectWithTag("SpawnP1").transform;
        HP = 100;
    }

    private void Update()
    {
        HPText.text ="HP-" + HP.ToString();
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
