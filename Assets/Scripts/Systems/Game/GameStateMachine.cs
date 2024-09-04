using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    public event Action OnGameStarted;
    public event Action OnVisitorInPlace;
    public event Action OnVisitorOutPlace;

    public GameState State { get; private set; }

    public void StartGame()
    {
        if (this.State != GameState.OFF)
        {
            return;
        }
        this.State = GameState.PLAY;
        this.OnGameStarted?.Invoke();
    }
    public void SwitchState(GameState state)
    {
        this.State = state;

        switch (state)
        {
            case GameState.VisitorOn:
                this.OnVisitorInPlace?.Invoke();
                break;

            case GameState.VisitorOff:
                this.OnVisitorOutPlace?.Invoke();
                break;

        }
    }
    

}
