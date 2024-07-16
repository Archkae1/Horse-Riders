using UnityEngine;
using Zenject;

public class DesktopInputHandler : MonoBehaviour, IInputHandler
{
    [Inject] private Player player;

    private void Awake() => enabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) PlayerJump();

        if (Input.GetKeyDown(KeyCode.A)) PlayerChangeLine(-1);

        if (Input.GetKeyDown(KeyCode.D)) PlayerChangeLine(1);
    }

    public void PlayerJump() => player.getPlayerController.TryJump();
    public void PlayerChangeLine(int xDirection) => player.getPlayerController.TryChangeLine(xDirection);
    public void EnableInput() => enabled = true;
    public void DisableInput() => enabled = false;
}

