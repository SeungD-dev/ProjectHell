using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{

   
    AttackEvent attackEvent;
   
    public Material[] ballcolor;
    Material[] mats;
    private Renderer ballRender;
   



    void Start()
    {
       
        attackEvent = FindObjectOfType<AttackEvent>();
        ballRender = GetComponent<Renderer>();
        mats = ballRender.sharedMaterials;
    }

    
    void Update()
    {
        if (attackEvent.bc == AttackEvent.ballColor.normal)
        {
           
            mats[0] = ballcolor[0];
            ballRender.materials = mats;
           
        }
        if (attackEvent.bc == AttackEvent.ballColor.red)
        {
           
            mats[0] = ballcolor[1];
            ballRender.materials = mats;


        }

        if (attackEvent.bc == AttackEvent.ballColor.green)
        {
           
            mats[0] = ballcolor[2];
            ballRender.materials = mats;

        }
        if (attackEvent.bc == AttackEvent.ballColor.blue)
        {
           
            mats[0] = ballcolor[3];
            ballRender.materials = mats;

        }
    }
}
