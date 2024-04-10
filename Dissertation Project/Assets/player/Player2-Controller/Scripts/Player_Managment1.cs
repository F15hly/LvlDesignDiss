﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Managment1 : MonoBehaviour
{
    Inputs1 inputs;
    public GameObject[] spawn;
    public GameObject currentspawn;
    public TextMeshProUGUI HPText;

    public GameObject HeatSigDeath, HeatSigWalk;
    public bool defeated;

    public int HP;

    private void Awake()
    {
        inputs = GetComponent<Inputs1>();
        spawn = GameObject.FindGameObjectsWithTag("Spawn");
        HP = 100;
        StartCoroutine(TrackMovement());
    }

    private void Update()
    {
        HPText.text = "HP-" + HP.ToString();
        inputs.HandleAllInputs();
        if (HP <= 0)
        {
            HP = 100;
            GetComponent<CharacterController>().enabled = false;
            Instantiate(HeatSigDeath, new Vector3(transform.position.x,21, transform.position.z), Quaternion.Euler(0, 0, 0));
            defeated = true;
            currentspawn = spawn[Random.Range(0, spawn.Length)];
            if (currentspawn.GetComponentInChildren<SpawnOccupied>().occupied)
            {
                currentspawn = spawn[Random.Range(0, spawn.Length)];
            }
            transform.position = new Vector3(currentspawn.transform.position.x, currentspawn.transform.position.y + 2, currentspawn.transform.position.z);
        }
        else
        {
            GetComponent<CharacterController>().enabled = true;
        }
    }

    IEnumerator TrackMovement()
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(HeatSigWalk, new Vector3(transform.position.x,20, transform.position.z), Quaternion.Euler(0, 0, 0));
        StartCoroutine(TrackMovement());
    }
}
