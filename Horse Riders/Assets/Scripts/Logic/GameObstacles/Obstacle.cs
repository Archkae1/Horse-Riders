using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    private Vector3 startLocalPosition;
    private GameInstance gameInstance;

    public abstract void ActiveAction();

    public abstract void DisableAction();

    public abstract void LoadObstacleComponent();

    public void Load(GameInstance gameInstance)
    {
        this.gameInstance = gameInstance;
        startLocalPosition = transform.localPosition;
        LoadObstacleComponent();
    }

    public void ResetPosition()
    {
        transform.localPosition = startLocalPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) gameInstance.EndGame();
    }
}
