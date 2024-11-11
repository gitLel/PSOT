using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;
    private StorageConfig storageConfig;
    private GuestSpawner guestSpawner;
    private ParcelStorage parcelStorage;
    private WallDrawer wallDrawer;

    [Inject]
    public void Construct(FiniteStateMachine finiteStateMachine, StorageConfig storageConfig, GuestSpawner guestSpawner, ParcelStorage parcelStorage, WallDrawer wallDrawer)
    {
        this.finiteStateMachine = finiteStateMachine;
        this.storageConfig = storageConfig;
        this.guestSpawner = guestSpawner;
        this.parcelStorage = parcelStorage; 
        this.wallDrawer = wallDrawer;
    }

    [SerializeField] private int maxBoxCount = 2;

    private void Start()
    {
        finiteStateMachine.AddState(new IdleState(finiteStateMachine));
        finiteStateMachine.AddState(new AccommodationState(finiteStateMachine, storageConfig, wallDrawer, maxBoxCount));
        finiteStateMachine.AddState(new WaitingState(finiteStateMachine, guestSpawner, parcelStorage));
    }
    private void Update()
    {
        finiteStateMachine.Update();
    }
}
