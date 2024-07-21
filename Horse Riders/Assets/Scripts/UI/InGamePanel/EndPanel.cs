using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text endText, restartText;

    private GameObject endPanel;

    public void Load()
    {
        endPanel = gameObject;
        endPanel.SetActive(false);
    }

    public void DefineUIText(UIText uiText)
    {
        endText.text = uiText.endText;
        restartText.text = uiText.restartText;
    }

    public void Enable() => endPanel.SetActive(true);
}
