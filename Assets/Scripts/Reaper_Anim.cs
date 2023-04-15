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
    public bool AtkTime1 = false, AtkTime2 = false;

    
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boss3_Status = FindObjectOfType<Boss3_Status>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 38.5)
        {
            AtkTime1 = true;
            anim.SetBool("Boss3_IsAtk1", true);
          

        }
        if(time >= 48.5)
        {
            AtkTime1 = false;
            anim.SetBool("Boss3_IsAtk1", false);
            anim.SetBool("Boss3_IsAtk2", true);
            
           
        }
        if (time >= 60.5)
        {
            anim.SetTrigger("Boss3_Atk2");
            AtkTime2 = false;
           
            
        }
        if (time >= 60.52)
        {
            anim.SetBool("Boss3_IsAtk2", false);
        }
      
        if (boss3_Status.currentHp >= 4)
        {
            AnimationUpdate();
        }
        else if(boss3_Status.currentHp <= 5)
        {
            AnimationUpdate_Low();
        }
      
        
    }

    void AnimationUpdate()
    {
        if (boss3_Status.isHit == true && anim.GetBool("Boss3IdleFull") == true && anim.GetBool("Boss3_isAtk1") == false)
        {
            anim.SetTrigger("Boss3Hit");
            boss3_Status.isHit = false;
        }
        
        if(boss3_Status.currentHp >= 4)
        {
            anim.SetBool("Boss3IdleFull", true);
            anim.SetBool("Boss3LowIdle", false);
        }
      
        if (boss3_Status.isHit==false &&   anim.GetBool("Boss3IdleFull") == true)
        {
            anim.SetTrigger("Boss3Idle");
        }
        
        //피가 많은 상태에서의 첫 번째 기믹
        if(AtkTime1 == true && anim.GetBool("Boss3_IsAtk1") == true)
        {
           
            anim.SetTrigger("Boss3_Atk");
        }
        if(boss3_Status.isHit_AtkTime1 == true && anim.GetBool("Boss3_IsAtk1") == true)
        {
            anim.SetTrigger("Boss3Hit_Atk");
            boss3_Status.isHit_AtkTime1 = false;
        }
        if(boss3_Status.isHit_AtkTime1 == false && AtkTime1 == true)
        {
            anim.SetTrigger("Boss3_Atk1");
        }


        if(AtkTime1 == false && anim.GetBool("Boss3_IsAtk1") == false)
        {
            anim.SetTrigger("Boss3Idle");
        }

        //피가 많은 상태에서의 두 번째 기믹
       /*if(AtkTime2==true)
        {
            anim.SetTrigger("Boss3_Atk2");
            
            //anim.SetBool("Boss3_IsAtk2", false);
            AtkTime2 = false;
        }*/
       if(AtkTime2 == false && anim.GetBool("Boss3IdleFull") == true && anim.GetBool("Boss3_IsAtk2") == false)
        {
            anim.SetTrigger("Boss3Idle");
            
        }
        
       
       
    }
    void AnimationUpdate_Low()
    {
        if (boss3_Status.currentHp <= 3)
        {
            anim.SetBool("Boss3IdleFull", false);
            anim.SetBool("Boss3LowIdle", true);
        }
        if (boss3_Status.isHit == true && anim.GetBool("Boss3LowIdle") == true)
        {
            anim.SetTrigger("Boss3Hit_Low");
            boss3_Status.isHit = false;
        }
        
        if (boss3_Status.isHit == false && anim.GetBool("Boss3LowIdle") == true)
        {
            anim.SetTrigger("Boss3Low");
        }
        
        if (AtkTime2==true)
        {
            anim.SetTrigger("Boss3_Atk2");
            //anim.SetBool("Boss3_IsAtk2", false);
            AtkTime2 = false;
        }
        if (AtkTime2 == false && anim.GetBool("Boss3LowIdle") == true && anim.GetBool("Boss3_IsAtk2") == false)
        {
            anim.SetTrigger("Boss3Low");
        }
        if(boss3_Status.currentHp == 0)
        {
            anim.SetTrigger("Boss3_Death");
        }

    }
}
