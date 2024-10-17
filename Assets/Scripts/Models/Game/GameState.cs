using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : StateModel<Game.State>
{
    public GameState() : base(Game.State.Idle)
    {

    }
}
