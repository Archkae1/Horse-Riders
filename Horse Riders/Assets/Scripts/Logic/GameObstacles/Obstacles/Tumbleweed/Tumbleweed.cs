using UnityEngine;

[RequireComponent(typeof(TumbleweedMover))]
public class Tumbleweed : Obstacle
{
    [SerializeField] private TumbleweedMover tumbleweedMover;

    public override void ActiveAction()
    {
        tumbleweedMover.enabled = true;
    }

    public override void DisableAction()
    {
        tumbleweedMover.StopMove();
        tumbleweedMover.enabled = false;
    }

    public override void LoadObstacleComponent()
    {
        tumbleweedMover.LoadTumbleweedMover();
    }
}
