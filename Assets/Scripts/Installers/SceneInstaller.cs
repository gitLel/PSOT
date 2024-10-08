using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //.FromComponentInHierarchy (������ ��������) - ���� ���������� �� ����� 
    //.Bind<���������>().To<�����>() - ����������� ����������� ��� ������
    //.BindInterfacesesTo<�����>() - ����������� ���� ����������� ��� ������

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

        this.Container.Bind<ParcelCamera>()
            .FromComponentInHierarchy()
            .AsSingle();

    }

    private void InstallStorage()
    {

        this.Container.Bind<ShelfManager>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container.Bind<StillageManager>()
            .FromComponentInHierarchy()
            .AsSingle();
    }

}