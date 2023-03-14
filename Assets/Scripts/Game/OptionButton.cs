using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public AudioMixer bgmMixer;
    public Slider bgmSlider;


    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        bgmMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }


    /*public void AudioControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) bgmMixer.SetFloat("BGM", -80);
        else bgmMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }*/
}
