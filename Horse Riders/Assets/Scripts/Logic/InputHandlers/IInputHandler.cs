public interface IInputHandler
{
    public void PlayerJump();
    public void PlayerChangeLine(int xDirection);
    public void PlayerForceDown();
    public void EnableInput();
    public void DisableInput();
}
