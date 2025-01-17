using DG.Tweening;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator cowboyAnimator;
    [SerializeField] private Animator horseAnimator;
    [SerializeField] private ParticleSystem pickupFX;

    public void Load()
    {
        cowboyAnimator.Play("Idle");
        horseAnimator.Play("Idle");
    }

    public void PlayRunAnimation()
    {
        horseAnimator.Play("Run");
        cowboyAnimator.Play("Run");
    }

    public void PlayEndAnimation()
    {
        horseAnimator.Play("Idle");
        cowboyAnimator.Play("End");
    }

    public void PauseHorseAnim()
    {
        horseAnimator.speed = 0f;
    }

    public void UnpauseHorseAnim()
    {
        horseAnimator.speed = 1f;
    }

    public void PlayPickupFX()
    {
        pickupFX.Play();
    }
}
