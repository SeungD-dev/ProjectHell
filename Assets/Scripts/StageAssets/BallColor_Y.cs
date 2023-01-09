using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor_Y : MonoBehaviour
{
    AttackEvent_Y attackEvent;

    public Material[] ballcolor;
    Material[] mats;
    private Renderer ballRender;

    void Start()
    {
        attackEvent = FindObjectOfType<AttackEvent_Y>();
        ballRender = GetComponent<Renderer>();
        mats = ballRender.sharedMaterials;
    }


    void Update()
    {
        if (attackEvent.bc == AttackEvent_Y.ballColor.normal)
        {
            mats[0] = ballcolor[0];
            ballRender.materials = mats;
        }
        if (attackEvent.bc == AttackEvent_Y.ballColor.red)
        {
            mats[0] = ballcolor[1];
            ballRender.materials = mats;
        }

        if (attackEvent.bc == AttackEvent_Y.ballColor.green)
        {
            mats[0] = ballcolor[2];
            ballRender.materials = mats;
        }
        if (attackEvent.bc == AttackEvent_Y.ballColor.blue)
        {
            mats[0] = ballcolor[3];
            ballRender.materials = mats;
        }
    }
}
