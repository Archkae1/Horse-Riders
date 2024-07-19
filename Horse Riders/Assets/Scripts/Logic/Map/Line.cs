using UnityEngine;

public struct Line
{
    private Transform transform;
    public LinePosition linePosition;

    public Line(Transform transform, LinePosition linePosition)
    {
        this.transform = transform;
        this.linePosition = linePosition;
    }

    public float getX()
    {
        return transform.position.x;
    }

    public bool isCanMoveToXDirection(int XDirection)
    {
        if (XDirection == -1 && linePosition == LinePosition.LEFT) return false;
        else if (XDirection == 1 && linePosition == LinePosition.RIGHT) return false;
        else return true;
    }

    public Line getLineFromXDirection(int XDirection,  PlayableLines playableLines)
    {
        if (XDirection == -1 && linePosition != LinePosition.LEFT)
        {
            return (linePosition == LinePosition.MIDDLE) ? 
                    playableLines.getLeftLine : 
                    playableLines.getMiddleLine;
        }
        else if (XDirection == 1 && linePosition != LinePosition.RIGHT)
        {
            return (linePosition == LinePosition.MIDDLE) ? 
                    playableLines.getRightLine : 
                    playableLines.getMiddleLine;
        }
        else
        {
            Debug.LogError("Cant getLineFromXDirection");
            return new Line();
        }
    }
}

public enum LinePosition
{
    LEFT,
    MIDDLE,
    RIGHT
}
