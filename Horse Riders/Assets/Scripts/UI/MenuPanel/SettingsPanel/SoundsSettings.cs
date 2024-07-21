using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundsSettings : MonoBehaviour
{

    [SerializeField] private TMP_Text musicText, soundsText, musicVolumeText, soundsVolumeText;
    [SerializeField] private Slider musicSlider, soundsSlider;

    public static Action<float> changeMusicVolume, changeSoundsVolume;

    public void Load()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            OnChangeMusicVolume();
        }
        if (PlayerPrefs.HasKey("SoundsVolume"))
        {
            soundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
            OnChangeSoundsVolume();
        }
    }

    public void DefineUIText(UIText uiText)
    {
        musicText.text = uiText.musicText;
        soundsText.text = uiText.soundsText;
    }

    public void OnChangeMusicVolume()
    {
        float _volume = musicSlider.value;
        musicVolumeText.text = _volume.ToString() + "%";
        changeMusicVolume?.Invoke(_volume / 100f);
        PlayerPrefs.SetFloat("MusicVolume", _volume);
        PlayerPrefs.Save();
    }

    public void OnChangeSoundsVolume()
    {
        float _volume = soundsSlider.value;
        soundsVolumeText.text = _volume.ToString() + "%";
        changeSoundsVolume?.Invoke(_volume / 100f);
        PlayerPrefs.SetFloat("SoundsVolume", _volume);
        PlayerPrefs.Save();
    }
}
