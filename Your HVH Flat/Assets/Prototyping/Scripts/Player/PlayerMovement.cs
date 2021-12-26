using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{ 
    private PlayerControls controls;
    private InputAction movement;
    private CharacterController controller;
    public Vector3 moveDir;

    public float speed;
    public float jumpHeight, gravity = 9.8f, fallSpeed = 1;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        movement = controls.Player.Movement;
        movement.Enable();

        controls.Player.Jump.performed += Jump;
        controls.Player.Jump.Enable();
    }


    private void Jump(InputAction.CallbackContext obj)
    {
        if (!controller.isGrounded)
            return;

        Debug.Log("Jump");
        moveDir.y = jumpHeight;
    }

    private void FixedUpdate()
    {
        //Debug.Log("Movement Values: " + movement.ReadValue<Vector2>());


        float moveX = movement.ReadValue<Vector2>().x;
        float moveY = movement.ReadValue<Vector2>().y;

        if(!controller.isGrounded)
        {
            moveDir.y -= gravity * Time.deltaTime;
        }


        moveDir = new Vector3(moveX, moveDir.y, moveY);



        controller.Move(transform.rotation * moveDir * speed * Time.deltaTime);
    }
    private void OnDisable()
    {
        movement.Disable();
        controls.Player.Jump.Disable();
    }
}
