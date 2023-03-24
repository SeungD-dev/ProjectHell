using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageButton : MonoBehaviour
{

    public Image fadePanel; //검은화면 컴포넌트
    public GameObject gameStartButton; //게임시작버튼 컴포넌트
                                     
    public void Button() //버튼 클릭시 호출
    {
        fadePanel.gameObject.SetActive(true); //패널 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("choiceMap", 0.3f); 
    }


    public void choiceMap()
    {
        SceneManager.LoadScene("StageScene"); //StageScene으로 전환
    }
    IEnumerator FadeOutCoroutine() //패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f) //알파값 변경 최소0 최대1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount); //페이드아웃 반복문
        }
    }
}
