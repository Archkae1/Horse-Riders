public class IdlePlayerState : IPlayerState
{
    private Player player;
    private PlayerSounds playerSounds;

    public IdlePlayerState(Player player, PlayerSounds playerSounds)
    {
        this.player = player;
        this.playerSounds = playerSounds;
    }

    public void Enter()
    {
        player.getInputHandler.DisableInput();
        playerSounds.OnPause();
        player.PauseMove();
    }

    public void Exit()
    {
        player.getInputHandler.EnableInput();
        player.StartMove();
        playerSounds.OnUnpause();
    }
}
