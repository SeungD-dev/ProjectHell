using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public Image fadePanel;
    public void RetryButton_Stage1()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("GoStage1", 0.3f); //0.3f후 실행
      
    }

    public void RetryButton_Stage2()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("GoStage2", 0.3f); //0.3f후 실행

    }
    public void RetryButton_Stage3()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("GoStage3", 0.3f); //0.3f후 실행
       
    }

    public void StageButton()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("ChooseStage", 0.3f); //0.3f후 실행

    }

    public void GoMainButton()
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("GoMain", 0.3f); //0.3f후 실행
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChooseStage()
    {
        SceneManager.LoadScene("StageScene");
    }



    public void GoStage1() //씬 전환
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void GoStage2()
    {
        SceneManager.LoadScene("Stage_2");
    }
    public void GoStage3()
    {
        SceneManager.LoadScene("Stage_3");
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
