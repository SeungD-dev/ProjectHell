using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive_3 : MonoBehaviour
{
    PlayerControl playerControl;
    public float time;
    public GameObject bind;
    public GameObject tiles;
    public GameObject BGM;
    public SpriteRenderer black;
    public bool on = false;
    public bool off = false;
    public bool fade = false;
    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        bind.SetActive(false);
        BGM.SetActive(false);
        GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(false);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0)
        {
            GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(true);
        }
        if(time >= 0.9f)
        {
            BGM.SetActive(true);
        }
        /*if(time >= 10 && !on)
        {
            StartCoroutine(FadeInCoroutine());
            on = true;
        }
        if(time >= 30 && !off)
        {
            StartCoroutine (FadeOutCoroutine());
            off = true;
        }*/
        if (time >= 38.5) //강림이 발묶기
        {
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
            bind.SetActive(true);
            playerControl.flip = true;
            playerControl.jumpCC = true;
            GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(true);
        }
        if(time>= 48.5)
        {
            bind.SetActive(false);
            playerControl.flip = false;
            playerControl.jumpCC = false;
        }
        if(time>= 59.5 && !on) //암전
        {
            StartCoroutine(FadeInCoroutine());
            on = true;
        }
        if (time >= 71.2)
        {
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
        }
        if (time >= 79 && !off)
        {
            StartCoroutine(FadeOutCoroutine());
            off = true;
        }

        if (fade)
        {
            tiles.SetActive(false);
        }
        else
        {
            tiles.SetActive(true);
        }
    }

    IEnumerator FadeInCoroutine() //패널의 알파값 조절 ( fadeIn ) 
    {
        yield return new WaitForSeconds(1f);
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount <= 1) //알파값 변경 최소0 최대1
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(255, 255, 255, fadeCount); //페이드인 반복문
            if (fadeCount >= 0.9)
            {
                fade = true;
            }
        }
        
    }

    IEnumerator FadeOutCoroutine() //패널의 알파값 조절 ( fadeIn ) 
    {
        yield return new WaitForSeconds(1f);
        float fadeCount = 1; //알파값(투명도)
        while (fadeCount > 0) //알파값 변경 최소0 최대1
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(255, 255, 255, fadeCount); //페이드인 반복문
            if (fadeCount <= 0.1)
            {
                fade = false;
            }
        }
    }
}
