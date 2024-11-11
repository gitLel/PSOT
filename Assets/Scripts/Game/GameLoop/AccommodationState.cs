using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccommodationState : State
{
    private readonly StorageConfig config;
    private readonly WallDrawer wallDrawer;
    private readonly int maxBoxCount;

    private int currentBoxCount = 0;


    public AccommodationState(FiniteStateMachine finiteStateMachine, StorageConfig config, WallDrawer wallDrawer, int boxCount) : base(finiteStateMachine)
    {
        this.config = config;
        this.wallDrawer = wallDrawer;
        this.maxBoxCount = boxCount;
    }

    public override void Update()
    {
        SpawnBox();

        if (currentBoxCount == maxBoxCount)
        {
            finiteStateMachine.SetState<WaitingState>();

        }
    }

    public override void Enter()
    {
        Debug.Log("Accomodation");

    }

    private void SpawnBox()
    {
        if (currentBoxCount < maxBoxCount)
        {
            if (wallDrawer.state == WallDrawer.State.FALSE)
            {
                if (wallDrawer.GetFirstEmptyTransformSlot() != null)
                {
                    if (wallDrawer.GetFirstEmptyTransformSlot() != null)
                    {
                        BoxSpawner.SpawnBox(config.box.GetComponent<Box>(), wallDrawer.GetFirstEmptyTransformSlot());
                        currentBoxCount++;

                    }

                }
            }

        }
    }
}
