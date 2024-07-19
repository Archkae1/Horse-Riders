using UnityEngine;
using Zenject;

public class MapControllerInstaller : MonoInstaller
{
    [SerializeField] private MapController mapController;

    public override void InstallBindings()
    {
        Container.Bind<MapController>()
            .FromInstance(mapController)
            .AsSingle();
    }
}