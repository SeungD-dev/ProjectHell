using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive_3 : MonoBehaviour
{
    PlayerControl playerControl;
    public float time;
    public GameObject bind;
    public SpriteRenderer black;
    bool on = false;
    bool off = false;
    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        bind.SetActive(false);
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
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
        }
        if(time >= 10 && !on)
        {
            StartCoroutine(FadeInCoroutine());
            on = true;
        }
        if(time >= 30 && !off)
        {
            StartCoroutine (FadeOutCoroutine());
            off = true;
        }
        if (time >= 38.5)
        {
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            bind.SetActive(true);
            playerControl.flip = true;
            playerControl.jumpCC = true;
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(true);
        }
        if(time>= 48.5)
        {
            bind.SetActive(false);
            playerControl.flip = false;
            playerControl.jumpCC = false;
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
        }
    }
}
