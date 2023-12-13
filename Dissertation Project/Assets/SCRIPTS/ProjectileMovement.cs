using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    public int DMG;

    public GameObject objHit;

    public float timer = 1f;

    Rigidbody rb;
    private bool bol = false;
    private void Awake()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody>();

        bol = true;
        gameObject.tag = "Bullet";

    }
    public void Update()
    {
        rb.velocity = transform.forward * projectileSpeed;

    }
    
    private void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject.name);
        objHit = GameObject.Find(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            
            print(collision.gameObject.name);
            if (bol)
            {
                TargetHit();
                bol = false;
                
            }


        }
        if (!(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "RoomClass"))
        {
            Destroy(gameObject);
        }
    }
    private void TargetHit()
    {
        objHit.GetComponent<PlayerStats>().HP -= DMG;
    }
}
