using System.Collections;
using TMPro;
using UnityEngine;

public class InGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TMP_Text startingText;

    [SerializeField] private PausePanel pausePanel;
    [SerializeField] private EndPanel endPanel;
    [SerializeField] private GameObject boostPanel;

    private GameObject inGamePanel;

    public void Load()
    {
        inGamePanel = gameObject;
        pausePanel.Load();
        endPanel.Load();
        BoostPanel[] _boostPanels = boostPanel.GetComponents<BoostPanel>();
        foreach (BoostPanel _boostPanel in _boostPanels)
            _boostPanel.Load();
        inGamePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void DefineUIText(UIText uiText)
    {
        pausePanel.DefineUIText(uiText);
        endPanel.DefineUIText(uiText);
        startingText.text = uiText.startingText;
    }

    public void OnEnterRunGameState()
    {
        startingText.gameObject.SetActive(false);
        inGamePanel.SetActive(true);
    }

    public void OnEnterPauseGameState()
    {
        pauseButton.SetActive(false);
        pausePanel.Enable();
    }

    public void OnExitPauseGameState()
    {
        pausePanel.Disable();
        startingText.gameObject.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void OnEnterEndGameState()
    {
        pauseButton.SetActive(false);
        StartCoroutine(LateActiveEndPanel());
    }

    public void ChangeStartingText(int seconds, UIText uiText)
    {
        startingText.text = uiText.startingText + seconds.ToString();
    }


    private IEnumerator LateActiveEndPanel()
    {
        yield return new WaitForSeconds(1.5f);
        endPanel.Enable();
    }
}
