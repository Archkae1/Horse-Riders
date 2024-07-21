using DG.Tweening;
using UnityEngine;

public class FallPlayerState : IPlayerState
{
    private Player player;
    private PlayerMover playerMover;
    private PlayerView playerView;
    private PlayerSounds playerSounds;

    public FallPlayerState(Player player, PlayerMover playerMover, PlayerView playerView, PlayerSounds playerSounds)
    {
        this.player = player;
        this.playerMover = playerMover;
        this.playerView = playerView;
        this.playerSounds = playerSounds;
    }

    public void Enter()
    {
        player.getInputHandler.DisableInput();
        player.StopAllCoroutines();
        if (player.getPlayerController.getIsJumping) 
            player.transform.DOMove(new Vector3(player.transform.position.x, 1f, player.transform.position.z), 0.5f);
        player.getCowboy.localPosition = new Vector3(0f, -1.42f, 0f);
        player.StopMove(true);

        playerMover.StopAllCoroutines();
        playerView.PlayEndAnimation();
        Boost.allBoostEnd?.Invoke();
        playerSounds.PlayFallSound();
    }

    public void Exit()
    {

    }
}
