using UnityEngine;
using Zenject;

public class MapGeneratorInstaller : MonoInstaller
{
    [SerializeField] private MapGenerator mapGenerator;

    public override void InstallBindings()
    {
        Container.Bind<MapGenerator>()
            .FromInstance(mapGenerator)
            .AsSingle();
    }
}