using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator cowboyAnimator;
    [SerializeField] private Animator horseAnimator;
    [SerializeField] private ParticleSystem pickupFX;

    public void LoadPlayerView()
    {
        cowboyAnimator.Play("Idle");
        horseAnimator.Play("Idle");
    }

    public void OnEnterRunPlayerState()
    {
        horseAnimator.Play("Run");
        cowboyAnimator.Play("Run");
    }

    public void OnEnterFallPlayerState()
    {
        horseAnimator.Play("Idle");
        cowboyAnimator.Play("End");
    }

    public void OnPickup()
    {
        pickupFX.Play();
    }
}
