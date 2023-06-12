using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSound : MonoBehaviour
{
    public AudioClip[] ad;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        switch (GameResultButton.clear)
        {

            case "Stage_1":
            case "Stage_2":
            case "Stage_3":
                audio.clip = ad[0];
                break;
        }

        switch (GameResultButton.fail)
        {
            case "Stage_1":
            case "Stage_2":
            case "Stage_3":
                audio.clip = ad[1];
                break;
        }

        audio.Play();
    }
}
