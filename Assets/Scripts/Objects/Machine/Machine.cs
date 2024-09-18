using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Machine : MonoBehaviour
{
    [SerializeField] private Transform outTransform;
    [SerializeField] private Transform inTransform;
    [SerializeField] private Transform takeTransform;

    [SerializeField] private int descentDuration;

    [SerializeField] private GameObject offLamp;
    [SerializeField] private GameObject redLamp;
    [SerializeField] private GameObject blueLamp;

    [SerializeField] private GameObject currentLamp;

    [SerializeField] private Transform lampPos;

    [SerializeField] private Transform outWallDrawer;
    [SerializeField] private Transform inWallDrawer;

    [SerializeField] private GameObject wallDrawer;

    public static Box boxSlot;

    [Inject]
    private ParcelCamera parcelCamera;



    private void Start()
    {
        SetLamp(offLamp);
        WallDraverMove(false);
    }

    private void SetLamp(GameObject lamp)
    {
        Destroy(currentLamp);
        currentLamp = Instantiate(lamp, lampPos);
        currentLamp.transform.localPosition = Vector3.zero;
        currentLamp.transform.localEulerAngles = Vector3.zero;
        currentLamp.transform.localScale = Vector3.one;
    }
    private void SetColorForLamp(bool isCurrect)
    {
        if (isCurrect)
        {
            SetLamp(blueLamp);

        }
        else
        {
            SetLamp(redLamp);

        }
    }
    private void AcceptBox()
    {
        if (boxSlot)
        {
            boxSlot.transform.position = inTransform.position;
            DOTween.Sequence()
                .Append(boxSlot.transform.DOMove(outTransform.position, descentDuration))
                .AppendInterval(.5f)
                .Append(boxSlot.transform.DOMove(takeTransform.position, descentDuration))
                ;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaceBoxInSlot(other);

        
    }

    private void PlaceBoxInSlot(Collider other)
    {
        if (other.TryGetComponent(out Box box))
        {
            if (box.gameObject.transform.parent == null)
            {
                boxSlot = box;
                boxSlot.GetComponent<Rigidbody>().isKinematic = true;
                AcceptBox();
                parcelCamera.PlaceParcelOnCamera(boxSlot.gameObject);

                if (boxSlot.boxNumberID == StorageConfig.currentBoxNumber)
                {
                    SetColorForLamp(true);
                    WallDraverMove(true);
                }
                else
                {
                    SetColorForLamp(false);
                    WallDraverMove(false);
                }
            }

        }
    }
    private void WallDraverMove(bool isTrue)
    {
        if(isTrue)
        {
            DOTween.Sequence()
                .Append(wallDrawer.transform.DOMove(outWallDrawer.position, descentDuration))
                ;
        }
        else
        {
            DOTween.Sequence()
                .Append(wallDrawer.transform.DOMove(inWallDrawer.position, descentDuration))
                ;
        }

    }
    
}
