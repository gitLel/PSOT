using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //.FromComponentInHierarchy (только монобехи) - ищет геймобжект на сцене 
    //.Bind<»терфейст>().To< ласс>() - регистраци€ интер€фейса дл€ класса
    //.BindInterfacesesTo< ласс>() - регистраци€ всех интерфейсов дл€ класса

    public override void InstallBindings()
    {
        InstallServices();
        InstallStorage();
        IstallOther();
        InstallGame();


        this.Container.Bind<VisitorSpawner>()
            .FromComponentInHierarchy()
            .AsSingle();


        this.Container.Bind<InputSystem>()
            .FromComponentInHierarchy()
            .AsSingle();

     
    }

    private void IstallOther()
    {
        this.Container.BindInterfacesAndSelfTo<RandomNumberGenerator>()
                    .AsSingle();

        this.Container.BindInterfacesAndSelfTo<RandomNameGenerator>()
            .AsSingle();

        this.Container.Bind<ParcelCamera>()
            .FromComponentInHierarchy()
            .AsSingle();

    }

    private void InstallGame()
    {
        this.Container.Bind<Game>().AsSingle();
        this.Container.Bind<GameState>().AsSingle();
    }

    private void InstallStorage()
    {

        this.Container.Bind<Shelf>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<WallDrawer>()
            .FromComponentInHierarchy()
            .AsSingle();

        

    }

    private void InstallServices()
    {
        this.Container.BindInterfacesAndSelfTo<AudioService>()
                   .AsSingle();
        
    }
}