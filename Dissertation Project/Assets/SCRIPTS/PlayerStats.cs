using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP;

    private void Awake()
    {
        HP = 100;
    }
    private void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
