using UnityEngine;
using Zenject;

public class InputHandlerInstaller : MonoInstaller
{
    [SerializeField] private DesktopInputHandler desktopInputHandler;
    [SerializeField] private MobileInputHandler mobileInputHandler;

    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Container.Bind<IInputHandler>()
            .To<DesktopInputHandler>()
            .FromComponentInNewPrefab(desktopInputHandler)
            .AsSingle();
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.Bind<IInputHandler>()
            .To<MobileInputHandler>()
            .FromComponentInNewPrefab(mobileInputHandler)
            .AsSingle();
        }
        else
        {
            Debug.Log("DEVICE DONT SUPPORT");
        }
    }
}