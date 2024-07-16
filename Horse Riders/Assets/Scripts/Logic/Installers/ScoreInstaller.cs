using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] Score score;

    public override void InstallBindings()
    {
        Container.Bind<Score>()
            .FromInstance(score)
            .AsSingle();
    }
}