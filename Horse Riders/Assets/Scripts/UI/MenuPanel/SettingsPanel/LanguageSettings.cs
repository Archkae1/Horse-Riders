using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LanguageSettings : MonoBehaviour
{
    [SerializeField] private TMP_Text languageText;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] UITextSelector uiTextSelector;

    [Inject] private UI ui;

    public void Load()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            dropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Language"));
            OnChangeLanguage();
        }
    }

    public void DefineUIText(UIText uiText)
    {
        languageText.text = uiText.languageText;
    }

    public void OnChangeLanguage()
    {
        int languageKey = dropdown.value;
        PlayerPrefs.SetInt("Language", languageKey);
        PlayerPrefs.Save();
        ui.ChangeLanguage(uiTextSelector.ChooseUIText(languageKey));
    }
}
