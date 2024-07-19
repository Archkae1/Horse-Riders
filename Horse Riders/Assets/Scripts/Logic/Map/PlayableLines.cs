using UnityEngine;

public class PlayableLines : MonoBehaviour
{
    [SerializeField]
    private Transform leftLineTransform, middleLineTransform, rightLineTransform;

    private Line leftLine, middleLine, rightLine;

    public Line getLeftLine { get { return leftLine; } }
    public Line getMiddleLine { get { return middleLine; } }
    public Line getRightLine { get { return rightLine; } }

    public void Load()
    {
        leftLine = new Line(leftLineTransform, LinePosition.LEFT);
        middleLine = new Line(middleLineTransform, LinePosition.MIDDLE);
        rightLine = new Line(rightLineTransform, LinePosition.RIGHT);
    }
}
