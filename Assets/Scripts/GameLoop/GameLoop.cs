using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;

    [Inject] private StorageConfig storageConfig;
    [Inject] private WallDrawer wallDrawer;

    [SerializeField] private int maxBoxCount;

    private void Start()
    {
        finiteStateMachine = new FiniteStateMachine();

        finiteStateMachine.AddState(new IdleState(finiteStateMachine));
        finiteStateMachine.AddState(new AccommodationState(finiteStateMachine, storageConfig, wallDrawer, maxBoxCount));

        finiteStateMachine.SetState<IdleState>();

        finiteStateMachine.SetState<AccommodationState>();

    }



    private void Update()
    {
        finiteStateMachine.Update();
    }
}
