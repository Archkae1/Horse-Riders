using System.Collections;
using UnityEngine;

public class LoadGameState : IGameState
{
    private GameInstance gameInstance;
    private Player player;
    private MapController mapController;
    private Score score;
    private CoinBank coinBank;
    private Music music;
    private UI ui;
    private GameStateMachine gameStateMachine;

    public LoadGameState(GameInstance gameInstance, Player player, MapController mapController, Score score, CoinBank coinBank, Music music, UI ui, GameStateMachine gameStateMachine)
    {
        this.gameInstance = gameInstance;
        this.player = player;
        this.mapController = mapController;
        this.score = score;
        this.coinBank = coinBank;
        this.music = music;
        this.ui = ui;
        this.gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        Debug.Log("Enter Load Game State");
        Time.timeScale = 0f;
        if (gameInstance.getIsGameLoadedOnce) LoadGameWithoutScreen();
        else gameInstance.StartCoroutine(LoadGameWithScreen());
    }

    public void Exit()
    {
        Debug.Log("Exit Load Game State");
    }

    private void LoadGameWithoutScreen()
    {
        mapController.Load(gameInstance);
        player.Load();
        score.Load();
        coinBank.Load();
        music.Load();
        ui.Load();
        gameStateMachine.Enter<ReadyGameState>();
    }

    private IEnumerator LoadGameWithScreen()
    {
        ui.ChangeLoadingStateInfo(0, "Generating Map");
        yield return null;
        mapController.Load(gameInstance);
        ui.ChangeLoadingStateInfo(17, "Preparing Player");
        yield return null;
        player.Load();
        ui.ChangeLoadingStateInfo(34, "Defining Score");
        yield return null;
        score.Load();
        ui.ChangeLoadingStateInfo(51, "Getting Info About Coins");
        yield return null;
        coinBank.Load();
        ui.ChangeLoadingStateInfo(68, "Loading Music");
        yield return null;
        music.Load();
        ui.ChangeLoadingStateInfo(85, "Preparing UI");
        yield return null;
        ui.Load();
        ui.ChangeLoadingStateInfo(100, "All Complete Successfully!");
        yield return null;
        Debug.Log("All Components Successfully Loaded");
        gameStateMachine.Enter<ReadyGameState>();
    }
}