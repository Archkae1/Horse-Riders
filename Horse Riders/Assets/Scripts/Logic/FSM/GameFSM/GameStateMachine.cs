using System.Collections.Generic;
using System;

public class GameStateMachine
{
    private Dictionary<Type, IGameState> states;
    private IGameState currentState;
    private Type typeOfCurrentState;

    public Type getTypeOfCurrentState { get { return typeOfCurrentState; } }

    public GameStateMachine(GameInstance gameInstance, Player player, MapController mapController, Score score, CoinBank coinBank, Music music, UI ui, GameSettingsChanger gameSettingsChanger)
    {
        states = new Dictionary<Type, IGameState>()
        {
            [typeof(LoadGameState)] = new LoadGameState(gameInstance, player, mapController, score, coinBank, music, ui, this, gameSettingsChanger),
            [typeof(ReadyGameState)] = new ReadyGameState(gameInstance, music, ui),
            [typeof(RunGameState)] = new RunGameState(player, score, music, ui),
            [typeof(PauseGameState)] = new PauseGameState(gameInstance, player, score, music, ui, this),
            [typeof(EndGameState)] = new EndGameState(player, mapController, music, ui, score, coinBank)
        };
    }

    public void Enter<TState>() where TState : IGameState
    {
        if (states.TryGetValue(typeof(TState), out IGameState state))
        {
            currentState?.Exit();
            if (typeOfCurrentState == typeof(PauseGameState)) return;
            currentState = state;
            typeOfCurrentState = typeof(TState);
            currentState.Enter();
        }
    }

    public void ForceEnter<TState>() where TState : IGameState
    {
        if (states.TryGetValue(typeof(TState), out IGameState state))
        {
            currentState = state;
            typeOfCurrentState = typeof(TState);
            currentState.Enter();
        }
    }
}