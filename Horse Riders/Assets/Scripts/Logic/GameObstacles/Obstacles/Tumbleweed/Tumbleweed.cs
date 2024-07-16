using UnityEngine;

[RequireComponent(typeof(TumbleweedMover))]
public class Tumbleweed : Obstacle
{
    private TumbleweedMover tumbleweedMover;

    public override void ActiveAction()
    {
        tumbleweedMover.enabled = true;
    }

    public override void DisableAction()
    {
        tumbleweedMover.StopMove();
        tumbleweedMover.enabled = false;
    }

    public override void LoadObstacle()
    {
        tumbleweedMover = GetComponent<TumbleweedMover>();
        tumbleweedMover.LoadTumbleweedMover();
    }
}
