using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStateMachine
{
    private Dictionary<Type, IPlayerState> states;
    private IPlayerState currentState;
    private Type typeOfCurrentState;

    public Type getTypeOfCurrentState { get { return typeOfCurrentState; } }

    public PlayerStateMachine(Player player, Rigidbody rigidbody, PlayerMover playerMover, PlayerController playerController, PlayerView playerView, PlayerBoosts playerBoosts, PlayerSounds playerSounds)
    {
        states = new Dictionary<Type, IPlayerState>()
        {
            [typeof(LoadPlayerState)] = new LoadPlayerState(player, rigidbody, playerMover, playerController, playerView, playerBoosts, playerSounds, this),
            [typeof(IdlePlayerState)] = new IdlePlayerState(player, playerSounds),
            [typeof(RunPlayerState)] = new RunPlayerState(playerView, playerSounds),
            [typeof(JumpPlayerState)] = new JumpPlayerState(playerView, playerController),
            [typeof(FallPlayerState)] = new FallPlayerState(player, playerMover, playerView, playerSounds)
        };
    }

    public void Enter<TState>() where TState : IPlayerState
    {
        if (states.TryGetValue(typeof(TState), out IPlayerState state))
        {
            currentState?.Exit();
            currentState = state;
            typeOfCurrentState = typeof(TState);
            currentState.Enter();
        }
    }
}