using UnityEngine;
using Zenject;

public class InputHandlerInstaller : MonoInstaller
{
    [SerializeField] private DesktopInputHandler desktopInputHandler;

    public override void InstallBindings()
    {

        Container.Bind<IInputHandler>()
            .To<DesktopInputHandler>()
            .FromComponentInNewPrefab(desktopInputHandler)
            .AsSingle();
    }
}