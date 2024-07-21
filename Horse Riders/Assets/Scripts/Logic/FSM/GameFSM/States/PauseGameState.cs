using System.Collections;
using UnityEngine;

public class PauseGameState : IGameState
{
    private GameInstance gameInstance;
    private Player player;
    private Score score;
    private Music music;
    private UI ui;
    private GameStateMachine gameStateMachine;

    public PauseGameState(GameInstance gameInstance, Player player, Score score, Music music, UI ui, GameStateMachine gameStateMachine)
    {
        this.gameInstance = gameInstance;
        this.player = player;
        this.score = score;
        this.music = music;
        this.ui = ui;
        this.gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        Debug.Log("Enter Pause Game State");
        Time.timeScale = 0f;
        player.OnEnterPauseGameState();
        score.OnEnterPauseGameState();
        music.OnEnterPauseGameState();
        ui.OnEnterPauseGameState();
    }

    public void Exit()
    {
        Debug.Log("Exit Pause Game State");
        ui.OnExitPauseGameState();
        ui.ChangeStartingText(3);
        gameInstance.StartCoroutine(LateExitPauseGameState());
    }

    private IEnumerator LateExitPauseGameState()
    {
        yield return new WaitForSecondsRealtime(1f);
        ui.ChangeStartingText(2);
        yield return new WaitForSecondsRealtime(1f);
        ui.ChangeStartingText(1);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        gameStateMachine.ForceEnter<RunGameState>();
    }
}