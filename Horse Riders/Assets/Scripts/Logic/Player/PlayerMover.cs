using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    private float speed;
    private bool isMovingSide = false;

    private new Rigidbody rigidbody;
    private PlayerController playerController;

    public float getSpeed { get { return speed; } }
    public bool getIsMovingSide { get { return isMovingSide; } }

    private void FixedUpdate()
    {
        speed = gameSettings.playerSpeed;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, speed);
    }

    public void Load(PlayerController playerController, Rigidbody rigidbody)
    {
        this.playerController = playerController;
        this.rigidbody = rigidbody;
        isMovingSide = false;
        speed = gameSettings.playerSpeed;
    }

    private void ApplySideVelocity(float XDirection)
    {
        rigidbody.velocity = new Vector3(XDirection * 5f, rigidbody.velocity.y, rigidbody.velocity.z);
    }

    public IEnumerator MoveToLine(Line targetLine, float currentX)
    {
        isMovingSide = true;

        if (transform.position.x > targetLine.getX())
        {
            while (transform.position.x >= targetLine.getX())
            {
                ApplySideVelocity(targetLine.getX() - currentX);
                yield return null;
            }
        }
        else
        {
            while (transform.position.x <= targetLine.getX())
            {
                ApplySideVelocity(targetLine.getX() - currentX);
                yield return null;
            }
        }

        rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, rigidbody.velocity.z);
        transform.position = new Vector3(targetLine.getX(), transform.position.y, transform.position.z);
        playerController.setCurrentLine = targetLine;
        
        isMovingSide = false;
    }
}
