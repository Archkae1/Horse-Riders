using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private Music music;
    private Player player;
    private MapController mapController;
    private Score score;
    private CoinBank coinBank;
    private UI ui;
    private GameStateMachine gameStateMachine;
    private bool isGameLoadedOnce = false;

    public Type getTypeOfCurrentStateGSM => gameStateMachine.getTypeOfCurrentState;
    public CoinBank getCoinBank => coinBank;
    public bool getIsGameLoadedOnce => isGameLoadedOnce;
    public bool setIsGameLoadedOnce { set { isGameLoadedOnce = value; } }

    [Inject]
    private void Construct(Player player, MapController mapController, Score score, CoinBank coinBank, UI ui)
    {
        this.player = player;
        this.mapController = mapController;
        this.score = score;
        this.coinBank = coinBank;
        this.ui = ui;
    }


    private void Awake()
    {
        gameStateMachine = new GameStateMachine(this, player, mapController, score, coinBank, music, ui);
        gameStateMachine.Enter<LoadGameState>();
    }

    public void StartGame() => gameStateMachine.Enter<RunGameState>();

    public void PauseGame()
    {
        if (gameStateMachine.getTypeOfCurrentState != typeof(PauseGameState)) gameStateMachine.Enter<PauseGameState>();
    }

    public void GoToMenu()
    {
        gameStateMachine.ForceEnter<LoadGameState>();
    }

    public void RestartGame()
    {
        GoToMenu();
        StartCoroutine(LateStartGame());
    }

    public void EndGame() => gameStateMachine.Enter<EndGameState>();

    private IEnumerator LateStartGame()
    {
        yield return null;
        StartGame();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause && (gameStateMachine.getTypeOfCurrentState == typeof(RunGameState))) PauseGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus && (gameStateMachine.getTypeOfCurrentState == typeof(RunGameState))) PauseGame();
    }

    private void OnApplicationQuit()
    {
        if (gameStateMachine.getTypeOfCurrentState == typeof(RunGameState)) PauseGame();
    }
}
