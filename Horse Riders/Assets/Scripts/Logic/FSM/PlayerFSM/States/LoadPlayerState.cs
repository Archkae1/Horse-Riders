using DG.Tweening;
using UnityEngine;

public class LoadPlayerState : IPlayerState
{
    private Player player;
    private Rigidbody rigidbody;
    private PlayerMover playerMover;
    private PlayerController playerController;
    private PlayerView playerView;
    private PlayerBoosts playerBoosts;
    private PlayerSounds playerSounds;
    private PlayerStateMachine playerStateMachine;

    public LoadPlayerState(Player player, Rigidbody rigidbody, PlayerMover playerMover, PlayerController playerController, PlayerView playerView, PlayerBoosts playerBoosts, PlayerSounds playerSounds, PlayerStateMachine playerStateMachine)
    {
        this.player = player;
        this.rigidbody = rigidbody;
        this.playerMover = playerMover;
        this.playerController = playerController;
        this.playerView = playerView;
        this.playerBoosts = playerBoosts;
        this.playerSounds = playerSounds;
        this.playerStateMachine = playerStateMachine;
    }

    public void Enter()
    {
        player.getInputHandler.DisableInput();

        player.StopAllCoroutines();
        player.transform.DOKill();
        player.transform.position = Vector3.up;
        player.getCowboy.localPosition = new Vector3(0f, -0.2f, 0f);

        playerMover.LoadPlayerMover(playerController, rigidbody);
        playerMover.StopAllCoroutines();

        playerController.LoadPlayerController(rigidbody, playerMover, playerSounds, playerStateMachine);

        playerView.LoadPlayerView();

        playerBoosts.LoadPlayerBoosts();
        Boost.allBoostEnd?.Invoke();

        playerSounds.LoadPlayerSounds();

        player.StopMove();
        playerStateMachine.Enter<IdlePlayerState>();
    }

    public void Exit()
    {

    }

}
