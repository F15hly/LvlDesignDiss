using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Managment : MonoBehaviour
{
    Inputs inputs;
    public GameObject[] spawn;
    public GameObject currentspawn;
    public TextMeshProUGUI HPText;

    public GameObject HeatSink;

    public int HP;

    public bool defeated;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        spawn = GameObject.FindGameObjectsWithTag("Spawn");
        HP = 100;
    }

    private void Update()
    {
        HPText.text = "HP-" + HP.ToString();
        inputs.HandleAllInputs();
        if (HP <= 0)
        {
            HP = 100;
            GetComponent<CharacterController>().enabled = false;
            Instantiate(HeatSink, transform.position, Quaternion.Euler(0, 0, 0));
            defeated = true;
            currentspawn = spawn[Random.Range(0, spawn.Length)];
            if(currentspawn.GetComponent<SpawnOccupied>().occupied)
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
}
