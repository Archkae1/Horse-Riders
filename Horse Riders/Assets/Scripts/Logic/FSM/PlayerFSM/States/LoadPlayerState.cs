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
        LoadComponents();
        player.getInputHandler.DisableInput();
        player.StopMove();
        player.StopAllCoroutines();
        player.transform.DOKill();
        player.transform.position = Vector3.up;
        player.getCowboy.localPosition = new Vector3(0f, -0.2f, 0f);

        playerMover.StopAllCoroutines();

        Boost.allBoostEnd?.Invoke();

        playerStateMachine.Enter<IdlePlayerState>();
    }

    public void Exit()
    {
        playerSounds.Load();
        playerMover.Load(playerController, rigidbody);
        playerController.Load(rigidbody, playerMover, playerSounds, playerStateMachine);
        playerView.Load();
        playerBoosts.Load();
    }

    private void LoadComponents()
    {

    }

}
