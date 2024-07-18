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

    public void PlayPickupFX()
    {
        pickupFX.Play();
    }
}
