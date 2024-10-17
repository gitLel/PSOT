using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Game : DisposableEntity
{
    public enum State
    {
        Idle,
        Accommodation,
        Expect,
        Verification,
    }

    [Inject]
    private readonly GameState gameState;

    [Inject]
    private readonly StorageConfig storageConfig;

    [Inject]
    private readonly WallDrawer wallDrawer;

    public ReactiveCommand AccommodationCommand { get; }
    public ReactiveCommand ExpectCommand { get; }
    public ReactiveCommand VerificationCommand { get; }

    //private int boxOnLevel = 3;

    public Game()
    {
        AccommodationCommand = new ReactiveCommand();
        AccommodationCommand.Subscribe(_ => StartAccommodation()).AddTo(this);

        ExpectCommand = new ReactiveCommand();
        ExpectCommand.Subscribe(_ => StartExpect()).AddTo(this);

        VerificationCommand = new ReactiveCommand();
        VerificationCommand.Subscribe(_ => StartVerification()).AddTo(this);
    }
    public void StartAccommodation()
    {
        gameState.State.Value = State.Accommodation;
        for(int i = 0; i < 1; i++)
        {
            BoxSpawner.SpawnBox(storageConfig.boxes[0].GetComponent<Box>(), wallDrawer.GetFirstEmptyTransformSlot());
        }
    }
    public void StartExpect()
    {
        gameState.State.Value = State.Expect;
    }
    public void StartVerification()
    {
        gameState.State.Value = State.Verification;
    }
}
