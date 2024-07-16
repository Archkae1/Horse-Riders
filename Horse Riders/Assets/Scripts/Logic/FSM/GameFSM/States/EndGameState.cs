using UnityEngine;

public class EndGameState : IGameState
{
    private Player player;
    private Music music;
    private UI ui;
    private Score score;
    private CoinBank coinBank;

    public EndGameState(Player player, Music music, UI ui, Score score, CoinBank coinBank)
    {
        this.player = player;
        this.music = music;
        this.ui = ui;
        this.score = score;
        this.coinBank = coinBank;
    }

    public void Enter()
    {
        Debug.Log("Enter End Game State");
        MapTile.enterEndGameState?.Invoke();
        player.OnEnterEndGameState();
        score.OnEnterEndGameState();
        coinBank.OnEnterEndGameState();
        music.OnEnterEndGameState();
        ui.OnEnterEndGameState();
    }

    public void Exit()
    {
        Debug.Log("Exit End Game State");
    }
}