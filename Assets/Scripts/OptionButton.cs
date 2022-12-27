using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public AudioMixer bgmMixer;
    public Slider bgmSlider;
    
    public void AudioControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) bgmMixer.SetFloat("BGM", -80);
        else bgmMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
