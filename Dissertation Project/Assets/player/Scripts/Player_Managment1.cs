using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Managment1 : MonoBehaviour
{
    Inputs1 inputs;
    public Transform spawn;
    public TextMeshProUGUI HPText;

    public GameObject HeatSink;
    public bool defeated;

    public int HP;

    private void Awake()
    {
        inputs = GetComponent<Inputs1>();
        spawn = GameObject.FindGameObjectWithTag("SpawnP2").transform;
        HP = 100;
    }

    private void Update()
    {
        HPText.text = "HP-" + HP.ToString();
        inputs.HandleAllInputs();
        if(HP <= 0)
        {
            Instantiate(HeatSink, transform.position, Quaternion.Euler(0, 0, 0));
            GetComponent<CharacterController>().enabled = false;
            transform.position = spawn.position;
            HP = 100;
            defeated = true;
        }
        else
        {
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
