using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMover), typeof(Rigidbody), typeof(PlayerController))]
[RequireComponent(typeof(PlayerView), typeof(PlayerSounds))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform cowboy;
    [SerializeField] private CapsuleCollider capsuleCollider;

    [Header("Player Components")]
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private PlayerSounds playerSounds;
    private PlayerStateMachine playerStateMachine;
    private PlayerBoosts playerBoosts;

    [Inject] private IInputHandler inputHandler;

    private int obstacleLayer => LayerMask.NameToLayer("Obstacle");
    private int groundLayer => LayerMask.NameToLayer("Ground");
    private int coinLayer => LayerMask.NameToLayer("Coin");
    private int boostLayer => LayerMask.NameToLayer("Boost");

    public Transform getCowboy => cowboy;
    public bool getIsJumping => playerController.getIsJumping;
    public float getSpeed => playerMover.getSpeed;
    public PlayerBoosts getPlayerBoosts => playerBoosts;
    public PlayerController getPlayerController => playerController;
    public IInputHandler getInputHandler => inputHandler;

    public static Action playerCollideObstacle, playerTriggerCoin;
    public static Action<Player> playerTriggerBoost;

    public void OnEnterLoadGameState()
    {
        DefineComponents();
        playerStateMachine.Enter<LoadPlayerState>();
    }

    public void OnEnterRunGameState()
    {
        if (getIsJumping) playerStateMachine.Enter<JumpPlayerState>();
        else playerStateMachine.Enter<RunPlayerState>();
    }

    public void OnEnterEndGameState()
    {
        playerStateMachine.Enter<FallPlayerState>();
    }

    public void OnEnterPauseGameState()
    {
        playerStateMachine.Enter<IdlePlayerState>();
    }

    public void StopMove(bool isEnd = false)
    {
        PauseMove();
        rigidbody.velocity = Vector3.zero;
        if (isEnd) capsuleCollider.enabled = false;
        else capsuleCollider.enabled = true;
        playerController.setIsJumping = false;
    }

    public void StartMove()
    {
        rigidbody.useGravity = true;
        playerMover.enabled = true;
    }

    public void PauseMove()
    {
        rigidbody.useGravity = false;
        playerMover.enabled = false;
    }

    private void DefineComponents()
    {
        playerBoosts = new PlayerBoosts();
        playerStateMachine = new PlayerStateMachine(this, rigidbody, playerMover, playerController, playerView, playerBoosts, playerSounds);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer && playerController.getIsJumping) playerController.CollideGround();

        if (collision.gameObject.layer == obstacleLayer) playerCollideObstacle?.Invoke();
    }

    private void OnTriggerEnter(Collider collider)
    {
        int _colliderLayer = collider.gameObject.layer;
        if (_colliderLayer == coinLayer || _colliderLayer == boostLayer)
        {
            if (_colliderLayer == coinLayer)
            {
                playerTriggerCoin?.Invoke();
                playerSounds.OnTriggerCoin();
            }
            else
            {
                playerTriggerBoost?.Invoke(this);
                playerSounds.OnTriggerBoost();
            }

            playerView.OnPickup();
            Destroy(collider.gameObject);
        }
    }
}