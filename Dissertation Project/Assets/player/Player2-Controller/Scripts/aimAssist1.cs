using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimAssist1 : MonoBehaviour
{
    public LayerMask mask;
    Movement1 movement;
    public float defaultSens, strength;

    private void Awake()
    {
        movement = GetComponent<Movement1>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            movement.rotateSpeed = defaultSens * strength;
        }
        else
        {
            movement.rotateSpeed = defaultSens;
        }
    }
}
