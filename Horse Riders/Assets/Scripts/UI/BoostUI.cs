using UnityEngine;
using UnityEngine.UI;
using System;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private Image multiplierScoreBoostImage;

    private void OnBoostStarted(Type type)
    {
        if (type == typeof(ScoreMultiplierBoost))
        {
            multiplierScoreBoostImage.color = Color.white;
        }
    }

    private void OnBoostEnded(Type type)
    {
        if (type == typeof(ScoreMultiplierBoost))
        {
            multiplierScoreBoostImage.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    private void OnAllBoostEnd()
    {
        multiplierScoreBoostImage.color = new Color(1f, 1f, 1f, 0.3f);
    }

    private void OnEnable()
    {
        Boost.boostStarted += OnBoostStarted;
        Boost.boostEnded += OnBoostEnded;
        Boost.allBoostEnd += OnAllBoostEnd;
    }

    private void OnDisable()
    {
        Boost.boostStarted -= OnBoostStarted;
        Boost.boostEnded -= OnBoostEnded;
        Boost.allBoostEnd -= OnAllBoostEnd;
    }
}
