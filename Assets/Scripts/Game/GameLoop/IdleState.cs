using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    
    public IdleState(FiniteStateMachine finiteStateMachine) : base(finiteStateMachine)
    {
        
    }
   
    public override void Enter()
    {
        Debug.Log("Idle");
    }
}
