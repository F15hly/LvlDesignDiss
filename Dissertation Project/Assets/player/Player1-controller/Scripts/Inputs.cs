using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    Shmoovment shmoovment;

    public Vector2 movementInp;
    public Vector2 rotationInp;

    public float xInp;
    public float yInp;
    public float rotInpX;
    public float rotInpY;

    public int inventSlot = 1;
    public bool shooting;
    public bool interacting;
    public bool heatMap;
    public bool reset;

    public bool openMap;

    public GameObject HeatCam;

    private void OnEnable()
    {
        if (shmoovment == null)
        {
            shmoovment = new Shmoovment();
            shmoovment.Player.Move.performed += i => movementInp = i.ReadValue<Vector2>();
            shmoovment.Player.Look.performed += i => rotationInp = i.ReadValue<Vector2>();
            shmoovment.Player.ItemSelect.performed += i => inventSlot += 1;
            shmoovment.Player.Fire.performed += i => shooting = i.ReadValueAsButton();
            shmoovment.Player.Action.performed += i => interacting = i.ReadValueAsButton();
            shmoovment.Player.Reset.performed += i => reset = i.ReadValueAsButton();
            shmoovment.Player.HeatMap.performed += i => heatMap = i.ReadValueAsButton();
        }
        shmoovment.Enable();
    }

    private void OnDisable()
    {
        shmoovment.Disable();
    }
    public void HandleAllInputs()
    {
        MovementInputHandler();
    }
    private void MovementInputHandler()
    {
        yInp = movementInp.y;
        xInp = movementInp.x;
        rotInpX = rotationInp.x;
        rotInpY = rotationInp.y;
    }

    private void LateUpdate()
    {
        if(reset)
        {
            gameObject.GetComponent<Player_Managment>().HP = 0;
            reset = false;
        }
        if(interacting)
        {
            interacting = false;
        }
        if(heatMap)
        {
            heatMap = false;
            openMap = !openMap;
        }
        if(openMap)
        {
            HeatCam.SetActive(true);
        }
        if(!openMap)
        {
            HeatCam.SetActive(false);
        }
    }
}
