using UnityEngine;

public class RunGameState : IGameState
{
    private Player player;
    private Score score;
    private Music music;
    private UI ui;

    public RunGameState(Player player, Score score, Music music, UI ui)
    {
        this.player = player;
        this.score = score;
        this.music = music;
        this.ui = ui;
    }

    public void Enter()
    {
        Debug.Log("Enter Run Game State");
        player.OnEnterRunGameState();
        score.OnEnterRunGameState();
        music.OnEnterRunGameState();
        ui.OnEnterRunGameState();
    }

    public void Exit()
    {
        Debug.Log("Exit Run Game State");
    }
}