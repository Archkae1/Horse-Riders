using UnityEngine;

public class EndGameState : IGameState
{
    private Player player;
    private MapController mapController;
    private Music music;
    private UI ui;
    private Score score;
    private CoinBank coinBank;

    public EndGameState(Player player, MapController mapController, Music music, UI ui, Score score, CoinBank coinBank)
    {
        this.player = player;
        this.mapController = mapController;
        this.music = music;
        this.ui = ui;
        this.score = score;
        this.coinBank = coinBank;
    }

    public void Enter()
    {
        Debug.Log("Enter End Game State");
        mapController.OnEnterEndGameState();
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