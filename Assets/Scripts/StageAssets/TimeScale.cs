using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{

    private float time;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            Time.timeScale = 2f;
            audioSource.pitch = 2f;
        }
        if(time>= 30f)
        {
            Time.timeScale = 0.5f;
            audioSource.pitch = 0.5f;
        }
        if(time >= 35f)
        {
            Time.timeScale = 1f;
            audioSource.pitch = 1f;
        }
    }
}
