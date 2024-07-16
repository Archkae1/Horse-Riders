public class RunPlayerState : IPlayerState
{
    private PlayerView playerView;
    private PlayerSounds playerSounds;

    public RunPlayerState(PlayerView playerView, PlayerSounds playerSounds)
    {
        this.playerView = playerView;
        this.playerSounds = playerSounds;
    }

    public void Enter()
    {
        playerView.OnEnterRunPlayerState();
        playerSounds.OnEnterRunPlayerState();
    }

    public void Exit()
    {
    }
}
