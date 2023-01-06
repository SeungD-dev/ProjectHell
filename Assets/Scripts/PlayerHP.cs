using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int player_MaxHP = 3;
    public int player_currentHP = 3;
    public SpriteRenderer[] hpImage = null;
    PlayerControl playerControl;
    SpriteRenderer sr;
    
    



    // Start is called before the first frame update
    void Start()
    {
        //ColorTransparency();
        playerControl = FindObjectOfType<PlayerControl>();
        sr =GetComponent<SpriteRenderer>();
        Debug.Log(this.gameObject.name);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player_currentHP == 0)
        {
            
            Debug.Log("사망");
            ExitGame();
            //Invoke("GameOver", 1f); 게임오버화면
        }


    }

    public void GameOver()
    {
        // SceneManager.LoadScene(게임오버 씬);
    }

    public void DecreaseHP(int p_num)
    {
        if(player_currentHP > 0)
        {
            player_currentHP -= p_num;
            //ShowHPImage();
        }
        if(player_currentHP == 2)
        {
            hpImage[2].color = new Color(255, 255, 255, 0);
        }
        else if(player_currentHP == 1)
        {
            hpImage[1].color = new Color(255, 255, 255, 0);
        }
    }

    public void IncreaseHP(int p_num)
    {
        if (player_currentHP < player_MaxHP)
            player_currentHP += p_num;
        else
            player_currentHP = player_MaxHP; //최대체력을 넘을 수 없도록
        //ShowHPImage();
        if(player_currentHP == player_MaxHP)
        {
            hpImage[0].color = new Color(255, 255, 255, 255);
            hpImage[1].color = new Color(255, 255, 255, 255);
            hpImage[2].color = new Color(255, 255, 255, 255);
            StartCoroutine(ShowHp());
        }
        else if (player_currentHP == 2)
        {
            hpImage[1].color = new Color(255, 255, 255, 255);
        }

    }

    /*void ShowHPImage()
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < player_currentHP)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }
    /*public void ColorTransparency() //체력바 투명도 0
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            Color color = hpImage[i].color;
            color.a = 0.0f;
            hpImage[i].color = color;
        }
    }
    /*public void UnColorTransparency() //체력바 투명도 100
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            Color color = hpImage[i].color;
            color.a = 1.0f;
            hpImage[i].color = color;
        }
    }*/

    IEnumerator ShowHp()
    {
        yield return new WaitForSeconds(2.0f);
        hpImage[0].color = new Color(255, 255, 255, 0);
        hpImage[1].color = new Color(255, 255, 255, 0);
        hpImage[2].color = new Color(255, 255, 255, 0);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
