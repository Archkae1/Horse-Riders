using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource hereToStay;
    [SerializeField] private AudioSource clavarLaEspada;

    private float hereToStayVolume = 0.1f;
    private float clavarLaEspadaVolume = 0.15f;

    public void Load()
    {
        hereToStay.volume = 0;
        clavarLaEspada.volume = 0;
        hereToStay.pitch = 0.75f;
        clavarLaEspada.pitch = 1f;
        hereToStay.Play();
        hereToStay.Stop();
        clavarLaEspada.Play();
        clavarLaEspada.Stop();
    }

    public void OnEnterReadyGameState()
    {
        StartCoroutine(SmoothChangeVolume(hereToStay, hereToStayVolume, 1f));
        hereToStay.Play();
    }

    public void OnEnterRunGameState()
    {
        StartCoroutine(SmoothChangeVolume(hereToStay, 0f, 1.4f));
        if (!clavarLaEspada.isPlaying) clavarLaEspada.Play();
        StartCoroutine(SmoothChangeVolume(clavarLaEspada, clavarLaEspadaVolume, 1.4f));
        StartCoroutine(SmoothChangePitch(clavarLaEspada, 1f, 1f));
    }

    public void OnEnterPauseGameState()
    {
        clavarLaEspada.volume = clavarLaEspadaVolume / 2;
        clavarLaEspada.pitch = 0.9f;
    }

    public void OnEnterEndGameState()
    {
        StartCoroutine(SmoothChangeVolume(clavarLaEspada, clavarLaEspadaVolume / 2, 1.4f))                                                                            ;
        StartCoroutine(SmoothChangePitch(clavarLaEspada, 0.9f, 1f));
    }

    private IEnumerator SmoothChangeVolume(AudioSource audioSource, float targetVolume, float duration)
    {
        float time = 0f;
        float startVolume = audioSource.volume;
        float volumeDiff = targetVolume - startVolume;
        while (time < duration)
        {
            audioSource.volume = startVolume + volumeDiff * (time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        if (targetVolume == 0) audioSource.Stop();
    }

    private IEnumerator SmoothChangePitch(AudioSource audioSource, float targetPitch, float duration, bool stopWhenEnd = false)
    {
        float time = 0f;
        float startPitch = audioSource.pitch;
        float pitchDiff = targetPitch - startPitch;
        while (time < duration)
        {
            audioSource.pitch = startPitch + pitchDiff * (time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }


}
