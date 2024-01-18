using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmg : MonoBehaviour
{
    public int dmg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player_Managment>().HP -= dmg;
            Destroy(gameObject);
        }
        if (other.tag == "Player1")
        {
            other.GetComponent<Player_Managment1>().HP -= dmg;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
