using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public abstract class BoostPanel : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoostPanel;
    [SerializeField] private Slider scoreBoostSlider;
    protected Type thisBoostType;

    public void Load()
    {
        scoreBoostPanel.SetActive(false);
        DefineType();
    }

    public abstract void DefineType();

    private void OnBoostStart(Type type, int time)
    {
        if (type == thisBoostType)
        {
            scoreBoostPanel.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(ChangeSlider(time));
        }
    }

    private void OnBoostEnd(Type type)
    {
        if (type == thisBoostType)
        {
            scoreBoostPanel.SetActive(false);
        }
    }

    private void OnAllBoostEnd()
    {
        scoreBoostPanel.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator ChangeSlider(int time)
    {
        float timer = 0;
        while (timer < time)
        {
            scoreBoostSlider.value = 1 - (timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void OnEnable()
    {
        Boost.boostStart += OnBoostStart;
        Boost.boostEnd += OnBoostEnd;
        Boost.allBoostEnd += OnAllBoostEnd;
    }

    private void OnDisable()
    {
        Boost.boostStart -= OnBoostStart;
        Boost.boostEnd -= OnBoostEnd;
        Boost.allBoostEnd -= OnAllBoostEnd;
    }
}
