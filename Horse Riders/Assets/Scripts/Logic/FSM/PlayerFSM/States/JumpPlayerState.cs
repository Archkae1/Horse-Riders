public class JumpPlayerState : IPlayerState
{
    private PlayerView playerView;
    private PlayerController playerController;

    public JumpPlayerState(PlayerView playerView, PlayerController playerController)
    {
        this.playerView = playerView;
        this.playerController = playerController;
    }

    public void Enter()
    {
        playerView.PauseHorseAnim();
        playerController.setIsJumping = true;
    }

    public void Exit()
    {
        playerView.UnpauseHorseAnim();
    }
}