using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject inGameUI, pausePanel, endPanel, pauseButton;
    [SerializeField] private TMP_Text startingText;
    
    [SerializeField] private GameObject menuUI, startText, loadScreen;
    [SerializeField] private TMP_Text loadingStateText, percentageText;
    [SerializeField] private Slider loadingSlider;

    public void Load()
    {
        endPanel.SetActive(false);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        inGameUI.SetActive(false);
        menuUI.SetActive(true);
        ScaleUp();
    }

    public void OnEnterReadyGameState()
    {
        loadScreen.SetActive(false);
    }

    public void OnEnterRunGameState()
    {
        startText.transform.DOKill();
        startText.transform.localScale = Vector3.one;
        startingText.gameObject.SetActive(false);
        menuUI.SetActive(false);

        inGameUI.SetActive(true);
    }

    public void OnEnterPauseGameState()
    {
        pausePanel.SetActive(true);
    }

    public void OnExitPauseGameState()
    {
        pausePanel.SetActive(false);
        startingText.text = "Starts in 3";
        startingText.gameObject.SetActive(true);
    }

    public void OnEnterEndGameState()
    {
        pauseButton.SetActive(false);
        StartCoroutine(LateActiveEndPanel());
    }

    public void ChangeStartingText(int seconds)
    {
        startingText.text = "Starts in " + seconds.ToString();
    }

    public void ChangeLoadingStateInfo(int loadingPercent, string loadingStateText)
    {
        loadingSlider.value = loadingPercent;
        percentageText.text = loadingPercent.ToString() + "%";
        this.loadingStateText.text = loadingStateText;
    }

    private IEnumerator LateActiveEndPanel()
    {
        yield return new WaitForSeconds(1.5f);
        endPanel.SetActive(true);
    }

    private void ScaleUp() => startText.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1.2f)
                                    .OnComplete(ScaleDown);

    private void ScaleDown() => startText.transform.DOScale(Vector3.one, 0.9f)
                                    .OnComplete(ScaleUp);
}
