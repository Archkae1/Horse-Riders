using UnityEngine;

public class PlayerSounds : MonoBehaviour 
{
    [SerializeField] private AudioSource runSource, jumpSource, fallSource, coinSource, boostSource;

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

    private void OnChangeSoundsVolume(float volume)
    {
        runSource.volume = volume;
        jumpSource.volume = volume;
        fallSource.volume = volume;
        coinSource.volume = volume;
        boostSource.volume = volume;
    }

    private void OnEnable()
    {
        SoundsSettings.changeSoundsVolume += OnChangeSoundsVolume;
    }

    private void OnDisable()
    {
        SoundsSettings.changeSoundsVolume -= OnChangeSoundsVolume;
    }
}
