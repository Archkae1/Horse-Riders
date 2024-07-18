using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private Music music;
    private Player player;
    private MapGenerator mapGenerator;
    private PlayableLines playableLines;
    private Score score;
    private CoinBank coinBank;
    private UI ui;
    private GameStateMachine gameStateMachine;
    private bool isGameLoadedOnce = false;

    public CoinBank getCoinBank => coinBank;
    public bool getIsGameLoadedOnce => isGameLoadedOnce;
    public bool setIsGameLoadedOnce { set { isGameLoadedOnce = value; } }

    [Inject]
    private void Construct(Player player, MapGenerator mapGenerator, PlayableLines playableLines, Score score, CoinBank coinBank, UI ui)
    {
        this.player = player;
        this.mapGenerator = mapGenerator;
        this.playableLines = playableLines;
        this.score = score;
        this.coinBank = coinBank;
        this.ui = ui;
    }


    private void Awake()
    {
        gameStateMachine = new GameStateMachine(this, player, mapGenerator, playableLines, score, coinBank, music, ui);
        gameStateMachine.Enter<LoadGameState>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && gameStateMachine.getTypeOfCurrentState == typeof(ReadyGameState))
            StartGame();
    }

    public void StartGame() => gameStateMachine.Enter<RunGameState>();

    public void PauseGame() => gameStateMachine.Enter<PauseGameState>();

    public void GoToMenu()
    {
        gameStateMachine.ForceEnter<LoadGameState>();
        StartCoroutine(LateReadyGame());
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

    private IEnumerator LateReadyGame()
    {
        yield return null;
        gameStateMachine.Enter<ReadyGameState>();
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
