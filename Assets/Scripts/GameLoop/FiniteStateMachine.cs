using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine 
{
    private State StateCurrent { get; set; }

    private Dictionary<Type, State> states = new();

    public void AddState(State state)
    {
        states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : State
    {
        var type = typeof(T);

        if(StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }

        if(states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();

            StateCurrent = newState;

            StateCurrent.Enter();
        }
    }
    public void Update()
    {
        StateCurrent?.Update();
    }
}
