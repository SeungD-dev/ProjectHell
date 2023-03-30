using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Reaper_Anim : MonoBehaviour
{
    public Animator anim;

    Boss3_Status boss3_Status;

    float time;
    public AudioSource audioSource;

    
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boss3_Status = FindObjectOfType<Boss3_Status>();
    }

    void Update()
    {
        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if (boss3_Status.isHit == true)
        {
            anim.SetTrigger("Boss3Hit");
            boss3_Status.isHit = false;
        }
        if(boss3_Status.currentHp >= 3)
        {
            anim.SetBool("Boss3IdleFull", true);
            anim.SetBool("Boss3IdleLow", false);
        }
        if (boss3_Status.currentHp <= 3)
        {
            anim.SetBool("Boss3IdleFull", false);
            anim.SetBool("Boss3IdleLow", true);
        }

        if (boss3_Status.isHit==false &&   anim.GetBool("Boss3IdleFull") == true)
        {
            anim.SetTrigger("Boss3Idle");
        }
        if(boss3_Status.isHit == false && anim.GetBool("Boss3IdleLow") == true)
        {
            anim.SetTrigger("Boss3IdleLow");
        }
       
    }
}
