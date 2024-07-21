using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MobileInputHandler : MonoBehaviour, IInputHandler
{
    [Inject] private Player player;

    private Vector3 downPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnFingerDown();
        else if (Input.GetMouseButtonUp(0)) OnFingerUp();
    }

    private void OnFingerDown()
    {
        downPosition = Input.mousePosition;
    }

    private void OnFingerUp()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 delta = currentPosition - downPosition;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0) PlayerChangeLine(1);
            else PlayerChangeLine(-1);
        }
        else
        {
            if (delta.y > 0) PlayerJump();
            else PlayerForceDown();
        }
    }

    public void PlayerJump() => player.getPlayerController.TryJump();
    public void PlayerChangeLine(int xDirection) => player.getPlayerController.TryChangeLine(xDirection);
    public void PlayerForceDown() => player.getPlayerController.TryForceDown();
    public void EnableInput() => enabled = true;
    public void DisableInput() => enabled = false;
}
