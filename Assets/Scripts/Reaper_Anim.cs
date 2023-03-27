using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Reaper_Anim : MonoBehaviour
{
    public Animator anim;

    Boss3_Status boss3_Status;

    
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if(boss3_Status.currentHp >= 3)
        {
            anim.SetBool("ReaperIdleFull", true);
            anim.SetBool("ReaperIdleLow", false);
        }
        if (boss3_Status.currentHp <= 3)
        {
            anim.SetBool("ReaperIdleFull", false);
            anim.SetBool("ReaperIdleLow", true);
        }

        if (anim.GetBool("ReaperIdleFull") == true)
        {
            anim.SetTrigger("ReaperIdle");
        }
       
    }
}
