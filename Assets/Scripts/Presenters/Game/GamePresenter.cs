using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePresenter : MonoBehaviour
{
    [Inject]
    private readonly Game game;

    [Inject]
    private readonly GameState gameState;

    private void Start()
    {
        game.StartAccommodation();
    }
}
