using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    private Obstacle[] obstacles;

    public void Load(GameInstance gameInstance)
    {
        obstacles = GetComponentsInChildren<Obstacle>();
        foreach (Obstacle _obstacle in obstacles) _obstacle.Load(gameInstance);
    }

    public void ActiveObstacles()
    {
        foreach (Obstacle _obstacle in obstacles) _obstacle.ActiveAction();
    }

    public void DisableObstacles()
    {
        foreach (Obstacle _obstacle in obstacles) _obstacle.DisableAction();
    }

    public void ResetObstacles()
    {
        DisableObstacles();
        foreach (Obstacle _obstacle in obstacles) _obstacle.ResetPosition();
    }
}
