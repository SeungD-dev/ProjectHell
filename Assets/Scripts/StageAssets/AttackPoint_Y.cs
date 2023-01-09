using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint_Y : MonoBehaviour
{
    PlayerControl_Y playerControl;

    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl_Y>();
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos;
    }
}
