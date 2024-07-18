using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    private GameInstance gameInstance;

    public abstract void ActiveAction();

    public abstract void DisableAction();

    public abstract void LoadObstacleComponent();

    public void Load(GameInstance gameInstance)
    {
        this.gameInstance = gameInstance;
        LoadObstacleComponent();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) gameInstance.EndGame();
    }
}
