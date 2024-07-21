using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float jumpForce;
    private bool isJumping = false;
    private bool isForcedDown = false;
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
            playerSounds.PlayJumpSound();
            playerStateMachine.Enter<JumpPlayerState>();
        }
    }

    public void ChangeLineTo(Line targetLine)
    {
        playerMover.StartCoroutine(playerMover.MoveToLine(targetLine, transform.position.x));
    }

    public void TryChangeLine(int XDirection)
    {
        if (!playerMover.getIsMovingSide && currentLine.isCanMoveToXDirection(XDirection))
            ChangeLineTo(currentLine.getLineFromXDirection(XDirection, playableLines));
    }

    public void TryForceDown()
    {
        if (!isForcedDown && playerStateMachine.getTypeOfCurrentState == typeof(JumpPlayerState))
        {
            if (rigidbody.velocity.y > 0) rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
            rigidbody.AddForce(-Vector3.up * jumpForce * 100);
            isForcedDown = true;
        }
    }

    public void CollideGround()
    {
        isForcedDown = false;
        isJumping = false;
        playerStateMachine.Enter<RunPlayerState>();
    }
}