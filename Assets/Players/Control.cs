using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Control : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 3;

    // camera and rotation
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    // gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0;

    void Update()
    {
        Move();
        Rotate();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);

    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
    
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);




    }
}