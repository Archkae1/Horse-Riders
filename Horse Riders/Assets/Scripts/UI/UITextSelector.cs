using UnityEngine;

public class UITextSelector : MonoBehaviour
{
    [SerializeField] private UIText russianUIText, englishUIText;

    public UIText ChooseUIText(int languageKey)
    {
        if (languageKey == 0) return russianUIText;
        else return englishUIText;
    }
}
