using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float speed;
    private bool isMovingSide = false;

    private new Rigidbody rigidbody;
    private PlayerController playerController;

    public float getSpeed { get { return speed; } }
    public bool getIsMovingSide { get { return isMovingSide; } }
    public bool setIsMovingSide { set { isMovingSide = value; } }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, speed);
    }

    public void Load(PlayerController playerController, Rigidbody rigidbody)
    {
        this.playerController = playerController;
        this.rigidbody = rigidbody;
        isMovingSide = false;
    }

    private void ApplySideVelocity(float XDirection)
    {
        rigidbody.velocity = new Vector3(XDirection * speed * 0.86f, rigidbody.velocity.y, rigidbody.velocity.z);
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
