using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider BgmSlider;
    public Slider PlayerHitSlider;
    public Slider BossHitSlider;
    public Slider MainBGM;
    public Slider MainClick;


    public void SetLevel ()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (BgmSlider.value) * 20);
    }

    public void SetPlayerHit()
    {
        mixer.SetFloat("PlayerHitSound", Mathf.Log10(PlayerHitSlider.value) * 20);
    }

    public void SetBossHit()
    {
        mixer.SetFloat("BossHitSound", Mathf.Log10(BossHitSlider.value) * 20);
    }

    public void SetMainBGM() 
    {
        mixer.SetFloat("MainBGM", Mathf.Log10(MainBGM.value) * 20);
    }

    public void SetMainClick()
    {
        mixer.SetFloat("MainClick", Mathf.Log10(MainClick.value) * 20);
    }
}
