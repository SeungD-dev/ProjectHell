using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResultButton : MonoBehaviour
{
    public static string clear, fail;
    public GameObject Stage1_Clear, Stage1_Fail, Stage2_Clear, Stage2_Fail, Stage3_Clear, Stage3_Fail;
    PlayerHP playerHP;

    void Start()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        Debug.Log(fail);
    }

    // Update is called once per frame
    void Update()
    {
        switch (clear)
        {
            case "Stage_1":
                Stage1_Clear.SetActive(true);
                break;
            case "Stage_2":
                Stage2_Clear.SetActive(true);
                break;
            case "Stage_3":
                Stage3_Clear.SetActive(true);
                break;
        }

        switch (fail)
        {
            case "Stage_1":
                Stage1_Fail.SetActive(true);
                break;
            case "Stage_2":
                Stage2_Fail.SetActive(true);
                break;
            case "Stage_3":
                Stage3_Fail.SetActive(true);
                break;
        }
    }

    public void GoTitle_Btn()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void SelectMap_Btn()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        SceneManager.LoadScene("StageScene");
    }

    public void RetryStage1_Btn()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        SceneManager.LoadScene("Stage_1");
    }

    public void RetryStage2_Btn()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        SceneManager.LoadScene("Stage_2");
    }

    public void RetryStage3_Btn()
    {
        Stage1_Clear.SetActive(false);
        Stage1_Fail.SetActive(false);
        Stage2_Clear.SetActive(false);
        Stage2_Fail.SetActive(false);
        Stage3_Clear.SetActive(false);
        Stage3_Fail.SetActive(false);
        SceneManager.LoadScene("Stage_3");
    }
}