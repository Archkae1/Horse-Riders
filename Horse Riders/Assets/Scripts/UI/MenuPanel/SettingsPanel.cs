using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text settingsText;

    [SerializeField] private LanguageSettings languageSettings;
    [SerializeField] private SoundsSettings soundsSettings;

    private GameObject settingsPanel;

    public void Load()
    {
        settingsPanel = gameObject;
        settingsPanel.SetActive(false);
        languageSettings.Load();
        soundsSettings.Load();
    }

    public void DefineUIText(UIText uiText)
    {
        languageSettings.DefineUIText(uiText);
        soundsSettings.DefineUIText(uiText);
        settingsText.text = uiText.settingsText;
    }

    public void Enable() => settingsPanel.SetActive(true);

    public void Disable() => settingsPanel.SetActive(false);
}
