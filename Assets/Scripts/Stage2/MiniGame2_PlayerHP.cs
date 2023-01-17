using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2_PlayerHP : MonoBehaviour
{
    public int player_MaxHP = 3;
    public int player_currentHP = 3;
    public Image[] hpImage = null;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(player_currentHP == 0)
        {
            Debug.Log("»ç¸Á");
            ExitGame();
        }
    }

    public void DecreaseHP(int p_num)
    {
        if (player_currentHP >= 0)
        {
            player_currentHP -= p_num;
           
        }
        if (player_currentHP == 2)
        {
            hpImage[0].color = new Color(255, 255, 255, 255);
            hpImage[1].color = new Color(255, 255, 255, 255);
            hpImage[2].color = new Color(255, 255, 255, 0);
        }
        else if (player_currentHP == 1)
        {
            hpImage[0].color = new Color(255, 255, 255, 255);
            hpImage[1].color = new Color(255, 255, 255, 0);
            hpImage[2].color = new Color(255, 255, 255, 0);
        }
    }

   

   
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
