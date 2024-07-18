using System.Collections.Generic;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacles;

    public void Load(GameInstance gameInstance)
    {
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
}
