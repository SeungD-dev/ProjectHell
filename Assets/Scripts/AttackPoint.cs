using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{

    PlayerControl playerControl;
    
   
    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        
    }

   
    void Update()
    {
        transform.localPosition = playerControl.player_Pos;
    }

   
}
