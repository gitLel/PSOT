using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    private VisitorSpawner visitorSpawner;
    private RandomNumberGenerator randomNumberGenerator;
    private GameStateMachine gameStateMachine;

    [Inject]
    public void Construct(
        VisitorSpawner visitorSpawner, 
        RandomNumberGenerator randomNumberGenerator, 
        GameStateMachine gameStateMachine
        )
    {
        this.visitorSpawner = visitorSpawner;
        this.randomNumberGenerator = randomNumberGenerator;
        this.gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        gameStateMachine.StartGame();
        visitorSpawner.Spawn();
        

    }
    private void Update()
    {
        
    }

}
