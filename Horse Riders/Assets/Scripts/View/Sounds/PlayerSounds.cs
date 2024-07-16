using UnityEngine;

public class PlayerSounds : MonoBehaviour 
{
    [SerializeField] private AudioSource runSource;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource fallSource;
    [SerializeField] private AudioSource coinSource;
    [SerializeField] private AudioSource boostSource;

    public void LoadPlayerSounds() => runSource.Stop();

    public void OnTriggerCoin() => coinSource.Play();

    public void OnTriggerBoost() => boostSource.Play();

    public void OnEnterRunPlayerState() => runSource.Play();

    public void OnJump()
    {
        runSource.Stop();
        jumpSource.Play();
    }

    public void OnFall()
    {
        runSource.Stop();
        fallSource.Play();
    }

    public void OnPause() => runSource.Pause();

    public void OnUnpause() => runSource.UnPause();
}
