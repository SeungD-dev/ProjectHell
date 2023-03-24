using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScene : MonoBehaviour
{
    public Image fadeInPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeInCoroutine"); //코루틴 함수 호출
    }

    // Update is called once per frame

    IEnumerator FadeInCoroutine() //패널의 알파값 조절 ( fadeIn ) 
    {
        float fadeCount = 1; //알파값(투명도)
        while (fadeCount > 0.0f) //알파값 변경 최소0 최대1
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeInPanel.color = new Color(0, 0, 0, fadeCount); //페이드인 반복문
        }
        gameObject.SetActive(false);
    }
}
