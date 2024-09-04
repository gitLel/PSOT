using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private Camera playerCamera;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float interactRange = 3;


    private float xRotation = 0f;

    private void Awake()
    {

        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();

        playerControls = new PlayerControls();
        playerControls.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
        Look();
        Interact();
    }

    private void Move()
    {
        Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (inputVector.y * transform.forward) + (inputVector.x * transform.right);
        movement.Normalize();

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

    private void Interact()
    {
        if (playerControls.Player.Interact.triggered)
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject))
                {
                    interactObject.Interact();
                }
            }
        }
    }
}
