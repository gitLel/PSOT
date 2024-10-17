using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] private Audio.Config audio;
    [SerializeField] private StorageConfig storage;
    public override void InstallBindings()
    {
        Container.BindInstance(audio);
        Container.BindInstance(storage);
    }
}