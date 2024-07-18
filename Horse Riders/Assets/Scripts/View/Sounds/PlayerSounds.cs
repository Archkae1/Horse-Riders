using UnityEngine;

public class PlayerSounds : MonoBehaviour 
{
    [SerializeField] private AudioSource runSource;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource fallSource;
    [SerializeField] private AudioSource coinSource;
    [SerializeField] private AudioSource boostSource;

    public void Load() => runSource.Stop();

    public void PlayCoinSound() => coinSource.Play();

    public void PlayBoostSound() => boostSource.Play();

    public void PlayRunSound() => runSource.Play();

    public void PlayJumpSound()
    {
        runSource.Stop();
        jumpSource.Play();
    }

    public void PlayFallSound()
    {
        runSource.Stop();
        fallSource.Play();
    }

    public void PauseSound() => runSource.Pause();

    public void UnpauseSound() => runSource.UnPause();
}
