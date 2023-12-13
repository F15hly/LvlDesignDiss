using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Inputs inputs;

    CharacterController controller;

    public Vector3 moveDirection;
    public Vector3 cameraDirection;

    public float speed;
    public float gravity = -10;
    public float sens = 15;

    public float lookAngX;
    public float lookAngY;
    public float rotateSpeed = 2;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance;

    public Transform pivot, cam/*, projSpawner*/;
    public float minPiv, maxPiv;

    private Animator anim;

    public bool canMove;

    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    public void HandleAllMovement()
    {
        Moving();
        Rotation();
    }

    private void Moving()
    {
        if(inputs.yInp == 0 && inputs.xInp == 0)
        {
            anim.SetInteger("Direction", 0);
        }
        if(inputs.yInp != 0)
        {
            if(inputs.yInp > 0)
            {
                anim.SetInteger("Direction", 1);
                if (inputs.xInp >= inputs.yInp)
                {
                    anim.SetInteger("Direction", 3);
                }
                if(inputs.xInp <= -inputs.yInp)
                {
                    anim.SetInteger("Direction", 4);
                }
            }
            if(inputs.yInp < 0)
            {
                anim.SetInteger("Direction", 2);
                if(inputs.xInp >= -inputs.yInp)
                {
                    anim.SetInteger("Direction", 3);
                }
                if(inputs.xInp <= inputs.yInp)
                {
                    anim.SetInteger("Direction", 4);
                }
            }
        }
        else if(inputs.xInp != 0)
        {
            if(inputs.xInp > 0)
            {
                anim.SetInteger("Direction", 3);
            }
            if(inputs.xInp < 0)
            {
                anim.SetInteger("Direction", 4);
            }
        }

        moveDirection = transform.forward * inputs.yInp;
        moveDirection = moveDirection + transform.right * inputs.xInp;

        moveDirection.Normalize();

        moveDirection = moveDirection * speed;
        moveDirection.y = gravity;

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

        rotation = Vector3.zero;
        targetRotation = Quaternion.Euler(rotation);
        pivot.localRotation = targetRotation;

        Vector3 camRot = Vector3.zero;
        camRot.x = lookAngY;
        Quaternion camY = Quaternion.Euler(camRot);
        cam.localRotation = camY;

        //Vector3 projrot = Vector3.zero;
        //projrot.x = lookAngY - 3;
        //projrot.y = 1;
        //Quaternion projY = Quaternion.Euler(projrot);
        //projSpawner.localRotation = projY;
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
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            HandleAllMovement();
        }

    }
}
