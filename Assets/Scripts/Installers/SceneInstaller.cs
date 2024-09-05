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
        InstallStorage();
        IstallOther();


        this.Container.Bind<VisitorSpawner>()
            .FromComponentInHierarchy()
            .AsSingle();


        this.Container.Bind<InputSystem>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<GameStateMachine>()
            .AsSingle();

    }

    private void IstallOther()
    {
        this.Container.BindInterfacesAndSelfTo<RandomNumberGenerator>()
                    .AsSingle();

        this.Container.BindInterfacesAndSelfTo<RandomNameGenerator>()
            .AsSingle();

    }

    private void InstallStorage()
    {

        this.Container.Bind<Shelf>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<StillageManager>()
            .FromComponentInHierarchy()
            .AsSingle();
    }

}