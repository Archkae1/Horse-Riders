using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayableLinesInstaller : MonoInstaller
{
    [SerializeField] private PlayableLines playableLines;

    public override void InstallBindings()
    {
        Container.Bind<PlayableLines>()
            .FromInstance(playableLines)
            .AsSingle();
    }
}
