using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Image fadePanel; //검은화면 오브젝트
    public AudioSource audioSource;
    public AudioSource monsterSource;
    public GameObject pausePanel_st3;
    public GameObject optionPanel_st3;


    GameManager gameManager;

    void Start()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.gameObject.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void pauseButton()
    {
        audioSource.Pause();
        fadePanel.gameObject.SetActive(true);
        gameManager.Pause();       
    }

    public void resumeButton() 
    {
        gameManager.Pause();
        fadePanel.gameObject.SetActive(false);
        audioSource.Play();
    }

    public void selectSceneButton()
    {
        SceneManager.LoadScene("MainScene"); //StageScene으로 전환
    }

    public void optionButton()
    {
        gameManager.optionPanel.gameObject.SetActive(true);
        fadePanel.gameObject.SetActive(false);
    }

    public void optionOkButton()
    {
        gameManager.optionPanel.gameObject.SetActive(false);
        fadePanel.gameObject.SetActive(true);
    }

    public void pauseButton_st3()
    {
        audioSource.Pause();
        monsterSource.Pause();
        pausePanel_st3.gameObject.SetActive(true);
        gameManager.Pause();
    }

    public void optionButton_st3()
    {
        pausePanel_st3.gameObject.SetActive(false);
        optionPanel_st3.gameObject.SetActive(true);
    }

    public void optionOkButton_st3()
    {
        optionPanel_st3.gameObject.SetActive(false);
        pausePanel_st3.gameObject.SetActive(true);
    }

    public void resumeButton_st3()
    {
        gameManager.Pause();
        pausePanel_st3.gameObject.SetActive(false);
        monsterSource.Play();
        audioSource.Play();
    }
}
