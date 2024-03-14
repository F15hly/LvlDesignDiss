using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int DMG = 1;
    public Inputs inputs;
    public bool canShoot, shot;
    public LayerMask opponentMask;
    public float fireRate;
    public LineRenderer LR;
    public Transform mesh;

    private void Awake()
    {
        canShoot = true;
        LR = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (inputs.shooting)
        {
            if (canShoot)
            {
                canShoot = false;
                StartCoroutine(ShotFired());
            }
        }
    }
    public void bulletFunction()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            LR.SetPosition(0, mesh.position);
            LR.SetPosition(1, hit.point);
            shot = true;
            StartCoroutine(Trail());
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, opponentMask))
        {
            Debug.Log("Did Hit");
            hit.collider.GetComponent<Player_Managment1>().HP -= DMG;
        }
    }
    IEnumerator ShotFired()
    {
        bulletFunction();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    IEnumerator Trail()
    {
        if(shot)
        {
            shot = false;
            LR.enabled = true;
            yield return new WaitForSeconds(0.2f);
            LR.enabled = false;
        }
    }
}
