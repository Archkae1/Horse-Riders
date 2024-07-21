using TMPro;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text pauseText, resumeText, quitText;

    private GameObject pausePanel;

    public void Load()
    {
        pausePanel = gameObject;
        pausePanel.SetActive(false);
    }

    public void DefineUIText(UIText uiText)
    {
        pauseText.text = uiText.pauseText;
        resumeText.text = uiText.resumeText;
        quitText.text = uiText.quitText;
    }

    public void Enable() => pausePanel.SetActive(true);

    public void Disable() => pausePanel.SetActive(false);
}
