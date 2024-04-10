using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOccupied : MonoBehaviour
{
    public bool occupied;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Player2")
        {
            occupied = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            occupied = false;
        }
    }
}
