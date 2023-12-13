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
        if(interacting)
        {
            interacting = false;
        }
    }
}
