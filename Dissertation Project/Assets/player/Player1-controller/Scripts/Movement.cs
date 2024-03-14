using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Inputs inputs;

    CharacterController controller;

    public Vector3 moveDirection;
    public Vector3 cameraDirection;
    public float xInp, yInp;

    public float speed;
    public float gravity = -10;
    public float sens = 15;

    public float lookAngX;
    public float lookAngY;
    public float rotateSpeed = 2;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance, vertSpeed;

    public Transform cam;
    public float minPiv, maxPiv;

    public bool canMove;

    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        controller = GetComponent<CharacterController>();
        canMove = true;
    }

    public void HandleAllMovement()
    {
        Moving();
        Rotation();
    }

    private void Moving()
    {
        //WASD
        yInp = inputs.yInp;
        xInp = inputs.xInp;

        moveDirection = transform.forward * yInp;
        moveDirection = moveDirection + transform.right * xInp;

        moveDirection.Normalize();

        moveDirection = moveDirection * speed;
        moveDirection.y = vertSpeed;

        Vector3 move = moveDirection;
        controller.Move(move * Time.deltaTime * speed);
    }

    private void Rotation()
    {
        Vector3 rotation = Vector3.zero;

        lookAngX = lookAngX + (inputs.rotInpX * rotateSpeed);
        lookAngY = lookAngY + (-inputs.rotInpY * rotateSpeed);
        lookAngY = Mathf.Clamp(lookAngY, minPiv, maxPiv);


        rotation = Vector3.zero;
        rotation.y = lookAngX;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        Vector3 camRot = Vector3.zero;
        camRot.x = lookAngY;
        Quaternion camY = Quaternion.Euler(camRot);
        cam.localRotation = camY;
    }

    private void Update()
    {
        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        vertSpeed = -gravity * 0.4f;

    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            HandleAllMovement();
        }

    }
}
