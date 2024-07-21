using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MenuPanel menuPanel;
    [SerializeField] private InGamePanel inGamePanel;
    [SerializeField] private LoadScreenPanel loadScreenPanel;

    [SerializeField] public UIText uiText;

    public void Load()
    {
        DefineUIText();
        menuPanel.Load();
        inGamePanel.Load();
        loadScreenPanel.Load();
    }

    public void DefineUIText()
    {
        menuPanel.DefineUIText(uiText);
        inGamePanel.DefineUIText(uiText);
        loadScreenPanel.DefineUIText(uiText);
    }

    public void OnEnterReadyGameState()
    {
        loadScreenPanel.OnEnterReadyGameState();
        menuPanel.OnEnterReadyGameState();
    }

    public void OnEnterRunGameState()
    {
        inGamePanel.OnEnterRunGameState();
        menuPanel.OnEnterRunGameState();
    }

    public void OnEnterPauseGameState()
    {
        inGamePanel.OnEnterPauseGameState();
    }

    public void OnExitPauseGameState()
    {
        inGamePanel.OnExitPauseGameState();
    }

    public void OnEnterEndGameState()
    {
        inGamePanel.OnEnterEndGameState();
    }

    public void ChangeLanguage(UIText uiText)
    {
        this.uiText = uiText;
        DefineUIText();
    }

    public void ChangeLoadingStateInfo(int loadingPercent, string loadingStateText) => 
        loadScreenPanel.ChangeLoadingStateInfo(loadingPercent, loadingStateText);

    public void ChangeStartingText(int seconds) =>
        inGamePanel.ChangeStartingText(seconds, uiText);
}
