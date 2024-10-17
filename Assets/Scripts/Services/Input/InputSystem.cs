using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour
{
    public PlayerControls playerControls;
    public Camera playerCamera;
    private CharacterController characterController;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float gravity = 9.81f * 2;


    [SerializeField] private float mouseSensitivity = 100f;

    private Vector3 defaultPosition;

    private float xRotation = 0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        playerControls = new PlayerControls();
        playerControls.Enable();

        defaultPosition = transform.position;

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
        Look();

    }

    private void Move()
    {
        Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (inputVector.y * transform.forward) + (inputVector.x * transform.right);
        movement.Normalize();

        movement.y -= gravity * Time.deltaTime;

        characterController.Move(movement * moveSpeed * Time.deltaTime);
    }



    private void Look()
    {
        Vector2 inputVector = playerControls.Player.Look.ReadValue<Vector2>();

        float mouseX = inputVector.x * mouseSensitivity * Time.deltaTime;
        float mouseY = inputVector.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    //private void Sit()
    //{
    //    if (playerControls.Player.Sit.triggered)
    //    {
    //        var n = new Vector3(defaultPosition.x, 0, defaultPosition.z);
    //        transform.position = n;
    //    }
        

    //}
}
