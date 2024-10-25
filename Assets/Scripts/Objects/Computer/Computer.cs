using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject display;

    [SerializeField] private GameObject player;

    private InputSystem inputSystem;
    private bool isEnable = false;

    [Inject]
    public void Construct(InputSystem inputSystem)
    {
        this.inputSystem = inputSystem;
    }

    private void Update()
    {
        HideCanvas();
    }
    public void Interact()
    {
        if (isEnable)
        {
            ShowCanvas();
        }
        isEnable = true;
        display.SetActive(true);

    }

    private void HideCanvas()
    {
        if (inputSystem.playerControls.Player.Escape.triggered)
        {
            canvas.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<InputSystem>().enabled = true;
        }
    }

   
    private void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<InputSystem>().enabled = false;
    }

}
