using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private Transform outTransform;
    [SerializeField] private Transform inTransform;
    [SerializeField] private Transform takeTransform;

    [SerializeField] private int descentDuration;

    public static Box boxSlot;


   
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
                AcceptBox();

            }

        }
    }
    
}
