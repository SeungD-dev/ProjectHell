using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //public Image fadeOutPanel; //검은화면 컴포넌트
    public GameObject StagePanel;
    public GameObject Tutorial_Panel;
    public GameObject Stage1_Panel;
    public GameObject Stage2_Panel;
    public GameObject Stage3_Panel;
    public GameObject OptionPanel;

    void Start()
    {
        StagePanel.SetActive(false);
        Tutorial_Panel.SetActive(false);
        Stage1_Panel.SetActive(false);
        Stage2_Panel.SetActive(false);
        Stage3_Panel.SetActive(false);
        OptionPanel.SetActive(false);
    }

    /*public void LoadingButton() //버튼클릭시 호출
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("LoadingSceneChange", 0.3f); //0.3f 후 Change실행
    }

    public void LoadingSceneChange() //씬 전환 함수
    {
        SceneManager.LoadScene("LoadingScene"); //LodingScene씬으로 전환
    }*/

    public void StageSelect()
    {
        StagePanel.SetActive(true);
    }

    public void Stage_BackButton()
    {
        StagePanel.SetActive(false);
    }

    public void Option()
    {
        OptionPanel.SetActive(true);
    }

    public void Option_BackButton()
    {
        OptionPanel.SetActive(false);
    }

    public void Stage_1Button() //버튼클릭시 호출
    {
        /*//fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("Stage_1SceneChange", 0.3f); //0.3f 후 Change실행*/
        StagePanel.SetActive(false);
        Stage1_Panel.SetActive(true);
    }

    public void Stage1_BackButton()
    {
        Stage1_Panel.SetActive(false);
        StagePanel.SetActive(true);
    }
    public void Stage2_Button() //버튼클릭시 호출
    {
        StagePanel.SetActive(false);
        Stage2_Panel.SetActive(true);
    }

    public void Stage2_BackButton()
    {
        Stage2_Panel.SetActive(false);
        StagePanel.SetActive(true);
    }

    public void Stage3_Button() //버튼클릭시 호출
    {
        StagePanel.SetActive(false);
        Stage3_Panel.SetActive(true);
    }

    public void Stage3_BackButton()
    {
        Stage3_Panel.SetActive(false);
        StagePanel.SetActive(true);
    }

    public void Tutorial_Button()
    {
        StagePanel.SetActive(false);
        Tutorial_Panel.SetActive(true);
    }

    public void Tutorial_BackButton()
    {
        Tutorial_Panel.SetActive(false);
        StagePanel.SetActive(true);
    }

    public void Main_SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void Stage1_SceneChange()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void Stage2_SceneChange()
    {
        SceneManager.LoadScene("Stage_2");
    }

    public void Stage3_SceneChange()
    {
        SceneManager.LoadScene("Stage_3");
    }

    public void Tutorial_SceneChange()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StageButton() //버튼클릭시 호출
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("StageChange", 0.3f); //0.3f 후 Change실행
    }

    public void StageChange() //씬 전환 함수
    {
        SceneManager.LoadScene("StageScene"); //LodingScene씬으로 전환
    }

    public void ExitButton()
    {
        ExitGame();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator FadeOutCoroutine()//패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f)//알파값 변경 최소0 최대1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            //fadeOutPanel.color = new Color(0, 0, 0, fadeCount);//페이드아웃 반복문
        }
    }
}
