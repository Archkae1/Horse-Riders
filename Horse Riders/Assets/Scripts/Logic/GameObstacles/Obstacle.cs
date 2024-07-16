using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public abstract void ActiveAction();

    public abstract void DisableAction();

    public abstract void LoadObstacle();
}
