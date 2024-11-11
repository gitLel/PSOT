using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //.FromComponentInHierarchy (������ ��������) - ���� ���������� �� ����� 
    //.Bind<���������>().To<�����>() - ����������� ����������� ��� ������
    //.BindInterfacesesTo<�����>() - ����������� ���� ����������� ��� ������

    public override void InstallBindings()
    {
        InstallServices();
        InstallStorage();
        IstallOther();
        InstallStateMachine();


        this.Container.Bind<InputSystem>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.BindInterfacesAndSelfTo<GuestSpawner>()
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


    private void InstallStateMachine()
    {
        this.Container.BindInterfacesAndSelfTo<FiniteStateMachine>()
                    .AsSingle(); 
    }

    private void InstallStorage()
    {

        this.Container.Bind<Shelf>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<WallDrawer>()
            .FromComponentInHierarchy()
            .AsSingle();
        this.Container.Bind<ParcelStorage>()
            .FromComponentInHierarchy()
            .AsSingle();
        
    }

    private void InstallServices()
    {
        this.Container.BindInterfacesAndSelfTo<AudioService>()
                   .AsSingle();
        
    }
}