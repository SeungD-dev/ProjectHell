using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GoTitle : MonoBehaviour
{

    public Image fadePanel; //검은화면 컴포넌트
    public void Button()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("Change", 0.3f); //0.3f후 Change실행
    }
    public void Change() //씬 전환
    {
        SceneManager.LoadScene("MainScene"); //MainScene으로
    }

    IEnumerator FadeOutCoroutine() //패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);//페이드아웃 반복문
        }
    }
}
