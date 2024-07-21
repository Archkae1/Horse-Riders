using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text loadingText, loadingStateText, percentageText;
    [SerializeField] private Slider loadingSlider;

    private GameObject loadScreenPanel;

    public void Load()
    {
        loadScreenPanel = gameObject;
    }

    public void DefineUIText(UIText uiText)
    {
        loadingText.text = uiText.loadingText;
        loadingStateText.text = uiText.loadingStateText;
    }

    public void OnEnterLoadGameState()
    {
        loadScreenPanel.SetActive(true);
    }

    public void OnEnterReadyGameState()
    {
        loadScreenPanel.SetActive(false);
    }

    public void ChangeLoadingStateInfo(int loadingPercent, string loadingStateText)
    {
        loadingSlider.value = loadingPercent;
        percentageText.text = loadingPercent.ToString() + "%";
        this.loadingStateText.text = loadingStateText;
    }
}
