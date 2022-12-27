using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Image fadePanel; //검은화면 오브젝트
    public Image optionPanel;

    GameManager gameManager;

    void Start()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.gameObject.SetActive(false);
        optionPanel = GetComponent<Image>();
        optionPanel.gameObject.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void pauseButton()
    {       
        fadePanel.gameObject.SetActive(true);
        //optionPanel.gameObject.SetActive(false);
        gameManager.Pause();       
    }

    public void resumeButton() 
    {
        gameManager.Pause();
        fadePanel.gameObject.SetActive(false);
    }

    public void selectSceneButton()
    {
        SceneManager.LoadScene("StageScene"); //StageScene으로 전환
    }

    public void optionButton()
    {
        optionPanel.gameObject.SetActive(true);
    }

    public void optionOkButton()
    {
        optionPanel.gameObject.SetActive(false);
    }
}
