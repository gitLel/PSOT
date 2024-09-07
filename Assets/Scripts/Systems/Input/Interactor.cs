using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;

    private InputSystem inputSystem;

    [SerializeField] private GameObject gameObj;


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
                if (gameObj == null)
                {
                    gameObj = hitInfo.collider.gameObject;

                    if (gameObj.TryGetComponent(out IInteractable interactObject))
                    {
                        interactObject.Interact();
                        SetObjectInHand(gameObj);
                    }
                    else
                    {
                        gameObj = null;
                        return;
                    }
                }


            }
        }

        DropObject(gameObj);

    }

    private void DropObject(GameObject obj)
    {
        if (obj != null)
        {
            if (inputSystem.playerControls.Player.DropItem.triggered)
            {
                if (gameObj.TryGetComponent(out ITakeable takeObject))
                {
                    SetObjectOutHand(obj);
                    gameObj = null;
                }
            }
        }
    }

    private void SetObjectOutHand(GameObject obj)
    {
        obj.transform.SetParent(null);
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Force);
        obj.transform.eulerAngles = Vector3.zero;

    }

    private void SetObjectInHand(GameObject obj)
    {
        if (transform.childCount < 1)
        {
            obj.transform.SetParent(transform);
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = Vector3.zero;
        }
        else return;

    }

    private void Update()
    {
        Interact();
    }
}
