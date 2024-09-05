using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;

    private InputSystem inputSystem;

    [Inject]
    public void Construct(InputSystem inputSystem)
    {
        this.inputSystem = inputSystem;
    }
    private void Interact()
    {
        if (inputSystem.playerControls.Player.Interact.triggered)
        {
            Ray ray = new Ray(inputSystem.playerCamera.transform.position, inputSystem.playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                var obj = hitInfo.collider.gameObject;

                if (obj.TryGetComponent(out IInteractable interactObject))
                {
                    interactObject.Interact();
                }

                if (obj.TryGetComponent(out ITakeable takeObject))
                {
                        SetObjectInHand(obj);
                }
            }
        }
    }

    private void SetObjectInHand(GameObject obj)
    {
        if (transform.childCount < 1)
        {
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            obj.transform.SetParent(null);
            obj.transform.position = transform.position;
        }
    }

    private void Update()
    {
        Interact();
    }
}
