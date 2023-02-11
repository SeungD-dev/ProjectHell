using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject backgroundMusic;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 2)
        {
            backgroundMusic.SetActive(true);
        }
    }
}
