    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class WaitingState : State
{
    private GuestSpawner guestSpawner;
    private ParcelStorage parcelStorage;

    private GameObject currentGuest;
    
    public WaitingState(FiniteStateMachine finiteStateMachine, GuestSpawner guestSpawner, ParcelStorage parcelStorage) : base(finiteStateMachine)
    {
        this.guestSpawner = guestSpawner;
        this.parcelStorage = parcelStorage;
    }
    public override void Enter()
    {
        Debug.Log("Waiting");
        currentGuest = guestSpawner.SpawnGuest(Resources.Load("Guest").GetComponent<Guest>(), parcelStorage.GetFirstEmptyTransformSlot());

    }

    public override void Update()
    {
        if (currentGuest)
        {
            
        }
    }
     
}
