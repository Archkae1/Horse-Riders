using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float jumpForce;
    private bool isJumping = false;
    private Line currentLine;

    private Rigidbody rigidbody;
    private PlayerMover playerMover;
    private PlayerSounds playerSounds;
    private PlayerStateMachine playerStateMachine;

    private PlayableLines playableLines;

    public bool getIsJumping => isJumping;
    public Line setCurrentLine { set { currentLine = value; } }
    public bool setIsJumping { set { isJumping = value; } }

    [Inject]
    private void Construct(MapController mapController)
    {
        playableLines = mapController.getPlayableLines;
    }

    public void Load(Rigidbody rigidbody, PlayerMover playerMover, PlayerSounds playerSounds, PlayerStateMachine playerStateMachine)
    {
        this.rigidbody = rigidbody;
        this.playerMover = playerMover;
        this.playerSounds = playerSounds;
        this.playerStateMachine = playerStateMachine;
        currentLine = playableLines.getMiddleLine;
    }

    public void TryJump()
    {
        if (playerStateMachine.getTypeOfCurrentState == typeof(RunPlayerState))
        {
            rigidbody.AddForce(Vector3.up * jumpForce * 100);
            isJumping = true;
            playerSounds.PlayJumpSound();
            playerStateMachine.Enter<JumpPlayerState>();
        }
    }

    public void ChangeLineTo(Line targetLine)
    {
        if (!playerMover.getIsMovingSide)
            playerMover.StartCoroutine(playerMover.MoveToLine(targetLine, transform.position.x));
    }

    public void TryChangeLine(int XDirection)
    {
        if (currentLine.isCanMoveToXDirection(XDirection))
            ChangeLineTo(currentLine.getLineFromXDirection(XDirection, playableLines));
    }

    public void CollideGround()
    {
        isJumping = false;
        playerStateMachine.Enter<RunPlayerState>();
    }
}