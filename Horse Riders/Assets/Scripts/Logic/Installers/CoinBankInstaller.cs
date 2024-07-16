using UnityEngine;
using Zenject;

public class CoinBankInstaller : MonoInstaller
{
    [SerializeField] CoinBank coinBank;

    public override void InstallBindings()
    {
        Container.Bind<CoinBank>()
            .FromInstance(coinBank)
            .AsSingle();
    }
}
