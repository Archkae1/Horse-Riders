using UnityEngine;

[CreateAssetMenu(fileName = "New Language", menuName = "ScriptableObjects/Language", order = -1)]
public class UIText : ScriptableObject
{
    [Header("Load Screen Panel")]
    public string loadingText;
    public string loadingStateText;
    public string loadingMapStateText;
    public string loadingPlayerStateText;
    public string loadingScoreStateText;
    public string loadingCoinsStateText;
    public string loadingMusicStateText;
    public string loadingUIStateText;
    public string successfullLoadingStateText;

    [Header("Menu Panel")]
    public string startText;

    [Header("In Game Panel")]
    public string startingText;

    [Header("End Panel")]
    public string endText;
    public string restartText;

    [Header("Pause Panel")]
    public string pauseText;
    public string resumeText;
    public string quitText;

    [Header("Settings Panel")]
    public string settingsText;
    public string languageText;
    public string musicText;
    public string soundsText;
}
