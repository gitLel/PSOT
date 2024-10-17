using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Machine : AbstractStorage, IInteractable
{
    [SerializeField] private GameObject slot;

    [SerializeField] private Transform inPort;
    [SerializeField] private Transform outPort;
    [SerializeField] private Transform takePort;

    [SerializeField] private float processDuration;
    [SerializeField] private float takePortDuration;

    
    public void Interact()
    {
       
       
    }

    private void PlaceInPort()
    {
        gameObj.transform.DOMove(inPort.position, .1f);
        gameObj.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void MoveOutPort()
    {
        gameObj.transform.DOMove(outPort.position, processDuration);
    }
    private void MoveTakePort()
    {
        gameObj.transform.DOMove(outPort.position, takePortDuration);
    }


}
