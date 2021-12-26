using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private PlayerControls controls;
    private Camera mainCam;

    private Vector3 cameraMovement;


    private InputAction mouseMove;

    private float lookX, lookY;

    private Transform player;
    public float sensX, sensY;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        mainCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Cursor.lockState = CursorLockMode.Locked;

    }
    private void OnEnable()
    {
        controls.Player.Look.Enable();

        mouseMove = controls.Player.Look;
        mouseMove.Enable();
    }


    private void Update()
    {
        lookX += mouseMove.ReadValue<Vector2>().x * Time.deltaTime * sensX;
        lookY += mouseMove.ReadValue<Vector2>().y * Time.deltaTime * sensY;

        lookY = Mathf.Clamp(lookY, -90, 90);
        
        //Debug.Log("Mouse Values: " + mouseMove.ReadValue<Vector2>());

        mainCam.transform.localRotation = Quaternion.Euler(Vector3.right * lookY);
        player.rotation = Quaternion.Euler(Vector3.up * lookX);



    }



}
