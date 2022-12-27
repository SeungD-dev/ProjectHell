using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Image fadePanel; //검은화면 오브젝트
    public AudioSource audioSource;

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
        SceneManager.LoadScene("StageScene"); //StageScene으로 전환
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
}
