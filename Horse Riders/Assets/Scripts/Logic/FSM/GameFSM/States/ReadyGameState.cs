using UnityEngine;

public class ReadyGameState : IGameState
{
    private GameInstance gameInstance;
    private Music music;
    private UI ui;

    public ReadyGameState(GameInstance gameInstance, Music music, UI ui)
    {
        this.gameInstance = gameInstance;
        this.music = music;
        this.ui = ui;
    }

    public void Enter()
    {
        Debug.Log("Enter Ready Game State");
        gameInstance.setIsGameLoadedOnce = true;
        Time.timeScale = 1f;
        music.OnEnterReadyGameState();
        ui.OnEnterReadyGameState();
    }

    public void Exit()
    {
        Debug.Log("Exit Ready Game State");
    }
}
