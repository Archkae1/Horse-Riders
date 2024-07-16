using System.Collections;
using UnityEngine;

public class LoadGameState : IGameState
{
    private GameInstance gameInstance;
    private Player player;
    private MapGenerator mapGenerator;
    private PlayableLines playableLines;
    private Score score;
    private CoinBank coinBank;
    private Music music;
    private UI ui;
    private GameStateMachine gameStateMachine;

    public LoadGameState(GameInstance gameInstance, Player player, MapGenerator mapGenerator, PlayableLines playableLines, Score score, CoinBank coinBank, Music music, UI ui, GameStateMachine gameStateMachine)
    {
        this.gameInstance = gameInstance;
        this.player = player;
        this.mapGenerator = mapGenerator;
        this.playableLines = playableLines;
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
        playableLines.OnEnterLoadGameState();
        mapGenerator.OnEnterLoadGameState();
        player.OnEnterLoadGameState();
        score.OnEnterLoadGameState();
        coinBank.OnEnterLoadGameState();
        music.OnEnterLoadGameState();
        ui.OnEnterLoadGameState();
        gameStateMachine.Enter<ReadyGameState>();
    }

    private IEnumerator LoadGameWithScreen()
    {
        ui.ChangeLoadingStateInfo(0, "Defining Playable Lines");
        yield return null;
        playableLines.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(15, "Generating Map");
        yield return null;
        mapGenerator.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(30, "Preparing Player");
        yield return null;
        player.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(45, "Defining Score");
        yield return null;
        score.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(60, "Getting Info About Coins");
        yield return null;
        coinBank.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(75, "Loading Music");
        yield return null;
        music.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(90, "Preparing UI");
        yield return null;
        ui.OnEnterLoadGameState();
        ui.ChangeLoadingStateInfo(100, "All Complete Successfully!");
        yield return null;
        Debug.Log("All Components Successfully Loaded");
        gameStateMachine.Enter<ReadyGameState>();
    }
}