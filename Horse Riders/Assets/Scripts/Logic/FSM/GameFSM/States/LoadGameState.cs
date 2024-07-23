using System.Collections;
using UnityEngine;

public class LoadGameState : IGameState
{
    private UIText uiText;
    private GameInstance gameInstance;
    private Player player;
    private MapController mapController;
    private Score score;
    private CoinBank coinBank;
    private Music music;
    private UI ui;
    private GameStateMachine gameStateMachine;
    private GameSettingsChanger gameSettingsChanger;

    public LoadGameState(GameInstance gameInstance, Player player, MapController mapController, Score score, CoinBank coinBank, Music music, UI ui, GameStateMachine gameStateMachine, GameSettingsChanger gameSettingsChanger)
    {
        this.gameInstance = gameInstance;
        this.player = player;
        this.mapController = mapController;
        this.score = score;
        this.coinBank = coinBank;
        this.music = music;
        this.ui = ui;
        this.gameStateMachine = gameStateMachine;
        this.gameSettingsChanger = gameSettingsChanger;
    }

    public void Enter()
    {
        Debug.Log("Enter Load Game State");
        Time.timeScale = 0f;
        uiText = ui.uiText;
        if (gameInstance.getIsGameLoadedOnce)
            OneFrameLoadGame();
        else
            gameInstance.StartCoroutine(LoadGame());
    }

    public void Exit()
    {
        Debug.Log("Exit Load Game State");
    }

    private void OneFrameLoadGame()
    {
        gameSettingsChanger.Load(gameInstance);
        ui.Load();
        uiText = ui.uiText;
        mapController.Load(gameInstance);
        player.Load();
        score.Load();
        coinBank.Load();
        music.Load();
        Debug.Log("All Components Successfully Loaded");
        gameStateMachine.Enter<ReadyGameState>();
    }

    private IEnumerator LoadGame()
    {
        gameSettingsChanger.Load(gameInstance);
        ui.ChangeLoadingStateInfo(0, uiText.loadingUIStateText);
        yield return null;
        ui.Load();
        uiText = ui.uiText;
        ui.ChangeLoadingStateInfo(17, uiText.loadingMapStateText);
        yield return null;
        mapController.Load(gameInstance);
        ui.ChangeLoadingStateInfo(34, uiText.loadingPlayerStateText);
        yield return null;
        player.Load();
        ui.ChangeLoadingStateInfo(51, uiText.loadingScoreStateText);
        yield return null;
        score.Load();
        ui.ChangeLoadingStateInfo(68, uiText.loadingCoinsStateText);
        yield return null;
        coinBank.Load();
        ui.ChangeLoadingStateInfo(85, uiText.loadingMusicStateText);
        yield return null;
        music.Load();
        ui.ChangeLoadingStateInfo(100, uiText.successfullLoadingStateText);
        yield return null;
        Debug.Log("All Components Successfully Loaded");
        gameStateMachine.Enter<ReadyGameState>();
    }
}