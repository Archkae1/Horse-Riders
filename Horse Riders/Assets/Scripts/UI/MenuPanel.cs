using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private TMP_Text startText;

    [SerializeField] private SettingsPanel settingsPanel;

    public SettingsPanel getSettingsPanel => settingsPanel;

    private GameObject menuPanel;

    public void Load()
    {
        menuPanel = gameObject;
        settingsPanel.Load();
        menuPanel.SetActive(false);
        ScaleUp();
    }

    public void DefineUIText(UIText uiText)
    {
        settingsPanel.DefineUIText(uiText);
        startText.text = uiText.startText;
    }

    public void OnEnterReadyGameState()
    {
        menuPanel.SetActive(true);
    }

    public void OnEnterRunGameState()
    {
        StopTextAnim();
        menuPanel.SetActive(false);
    }

    public void StopTextAnim()
    {
        startText.transform.DOKill();
        startText.transform.localScale = Vector3.one;
    }

    private void ScaleUp() => startText.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1.2f)
                                    .OnComplete(ScaleDown);

    private void ScaleDown() => startText.transform.DOScale(Vector3.one, 0.9f)
                                    .OnComplete(ScaleUp);

}
