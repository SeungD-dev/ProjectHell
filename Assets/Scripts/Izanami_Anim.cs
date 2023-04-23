using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Izanami_Anim : MonoBehaviour
{
    public Animator anim;
    Boss2_Status boss2_Status;
    BossRandomMove_Y brm;

    float time;

    bool goIdle= false;
   
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boss2_Status = FindObjectOfType<Boss2_Status>();
        brm = FindObjectOfType<BossRandomMove_Y>();
    }

  
    void Update()
    {
        time += Time.deltaTime;
        PositionAnimUpdate();
        AnimationUpdate();
    }

    void AnimationUpdate()
    {

        //보스 검기 애니메이션
        if (time >= 10) //10
        {
            anim.SetBool("Boss2_IsAtk1", true);
        }
        if (time >= 54.8) //55.8
        {
            anim.SetTrigger("Boss2_Atk1");
        }
        if (time >= 56.1) //56
        {
            anim.SetBool("Boss2_IsAtk1", false);
        }
       

        //보스 각성 애니메이션
        if (time >= 99)
        {
            anim.SetBool("Boss2_isIdle2", true);
            anim.SetTrigger("Boss2_Transform");
        }
        if (time >= 99.93)
        {
            anim.SetTrigger("Boss2_Idle2");
        }
        
        //각성 전 보스 히트
        if(boss2_Status.isHit == true && anim.GetBool("Boss2_isIdle1")==true && anim.GetBool("Boss2_isIdle2") == false)
        {
            anim.SetTrigger("Boss2_Hit1");
            boss2_Status.isHit = false;
        }

        //보스 체력 많을 때 Idle
        if (boss2_Status.currentHp >= 5)
        {
            anim.SetBool("Boss2_isIdle1", true);
            anim.SetBool("Boss2_Low", false);
        }
        if(boss2_Status.isHit == false && anim.GetBool("Boss2_isIdle1") == true)
        {
            anim.SetTrigger("Boss2Idle");
        }


        //보스 사망 애니메이션
        if(boss2_Status.currentHp == 0)
        {
            anim.SetTrigger("Boss2_Death");
        }

    }

    void PositionAnimUpdate()
    {
        if(time >= 56.3)
        {
            if (brm.newX == 0f)
            {
                anim.SetBool("Boss2_IsAtk1",true);
                anim.SetTrigger("Boss2_Atk1");
                anim.SetBool("Boss2_IsAtk2", false);
              
            }
            if (brm.newX == -1.76f || brm.newX == -0.88f || brm.newX == 0.88f || brm.newX == 1.76f)
            {
                anim.SetBool("Boss2_IsAtk1", false);
                anim.SetBool("Boss2_IsAtk2", true);
                anim.SetTrigger("Boss2_Atk2");
               
               
            }
        }
        if (time >= 56.33)
        {
            if (anim.GetBool("Boss2_IsAtk1") == true)
            {
                anim.SetTrigger("Boss2_Atk1");
                
                anim.SetBool("Boss2_IsAtk1", false);
                goIdle = true;
            }

            if (anim.GetBool("Boss2_IsAtk2") == true)
            {
                anim.SetTrigger("Boss_Atk2");
                anim.SetBool("Boss2_IsAtk2", false);
                goIdle = true;
            }
            
        }
        if (anim.GetBool("Boss2_IsAtk1") == false && goIdle ==true)
        {
            anim.SetTrigger("Boss2Idle");
            goIdle = false;
        }
        if (anim.GetBool("Boss2_IsAtk2") == false && goIdle == true)
        {
            anim.SetTrigger("Boss2Idle");
            goIdle = false;
        }
    }
}
