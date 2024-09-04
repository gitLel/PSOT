using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //.FromComponentInHierarchy (только монобехи) - ищет геймобжект на сцене 
    //.Bind<»терфейст>().To< ласс>() - регистраци€ интер€фейса дл€ класса
    //.BindInterfacesesTo< ласс>() - регистраци€ всех интерфейсов дл€ класса

    private VisitorConfig visitorConfig;

    public override void InstallBindings()
    {
        InstallStorageObjects();

        this.Container.Bind<InputSystem>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<VisitorSpawner>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.BindInterfacesAndSelfTo<RandomNumberGenerator>()
            .AsSingle();

        this.Container.BindInterfacesAndSelfTo<RandomNameGenerator>()
            .AsSingle();

        this.Container.Bind<GameStateMachine>()
            .AsSingle();

        //TEST
        //this.Container.BindInterfacesTo<MoveInput>().AsSingle();

    }

    private void InstallStorageObjects()
    {
        this.Container.Bind<StorageManager>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<Shelf>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}