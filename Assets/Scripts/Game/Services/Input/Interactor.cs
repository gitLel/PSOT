using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;

    private InputSystem inputSystem;

    private GameObject currentObject;

    private Ray ray;

    [Inject]
    public void Construct(InputSystem inputSystem)
    {
        this.inputSystem = inputSystem;
    }

    private void Start()
    {
        var interactStream = this.UpdateAsObservable()
            .Where(_ => inputSystem.playerControls.Player.Interact.triggered)
            .Subscribe(_ =>
            {
                InteractObject();
            });

        var dropStream = this.UpdateAsObservable()
            .Where(_ => inputSystem.playerControls.Player.DropItem.triggered)
            .Subscribe(_ =>
            {
                DropObject(currentObject);
            });

    }

    private void InteractObject()
    {
        ray = new Ray(inputSystem.playerCamera.transform.position, inputSystem.playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactObject))
            {
                interactObject.Interact();
            }

            if (currentObject == null)
            {
                currentObject = hitInfo.collider.gameObject;

                if (currentObject.TryGetComponent(out ITakeable takeObject))
                {
                    SetObjectInHand(currentObject);
                }
                else
                {
                    currentObject = null;
                }
            }

        }
    }

    private void DropObject(GameObject obj)
    {
        ray = new Ray(inputSystem.playerCamera.transform.position, inputSystem.playerCamera.transform.forward);

        if (obj)
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.TryGetComponent(out AbstractStorage storage))
                {
                    storage.gameObj = obj;
                    if (storage.TryPlace())
                    {
                        currentObject = null;

                    }
                    return;
                }
                else
                {
                    Debug.Log("Obstacle!");
                    return;
                }
            }
            SetObjectOutHand(obj);
            currentObject = null;
        }
    }
    private void SetObjectOutHand(GameObject obj)
    {
        obj.transform.SetParent(null);
        obj.GetComponent<BoxCollider>().enabled = true;
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.GetComponent<Rigidbody>().useGravity = true;
        //obj.transform.eulerAngles = Vector3.zero;
        obj.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Force);

    }
    private void SetObjectInHand(GameObject obj)
    {
        if (transform.childCount < 1)
        {
            obj.transform.SetParent(transform);
            obj.GetComponent<BoxCollider>().enabled = false;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = Vector3.zero;
        }
        else return;

    }
}
