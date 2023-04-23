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
        float duration = 3.5f;

   

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boss2_Status = FindObjectOfType<Boss2_Status>();
        brm = FindObjectOfType<BossRandomMove_Y>();
    }


    void Update()
    {
        time += Time.deltaTime;
        AnimationUpdate();


        PositionAnimUpdate();

    }

    void AnimationUpdate()
    {

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
        if (boss2_Status.isHit == true && anim.GetBool("Boss2_isIdle1") == true && anim.GetBool("Boss2_isIdle2") == false)
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
        if (boss2_Status.isHit == false && anim.GetBool("Boss2_isIdle1") == true)
        {
            anim.SetTrigger("Boss2Idle");
        }


        //보스 사망 애니메이션
        if (boss2_Status.currentHp == 0)
        {
            anim.SetTrigger("Boss2_Death");
        }


    }

    void PositionAnimUpdate()
    {
        switch (brm.newX)
        {
            case 0f:
                if (time >= 56f && anim.GetCurrentAnimatorStateInfo(0).IsName("Boss2_Idle"))
                {
                    duration += Time.deltaTime;
                    if(duration >= 4f)
                    {
                        anim.SetTrigger("Boss2_Atk1");
                        duration = 0f;
                    }
                    
                    //yield return new WaitForSeconds(1f);
                    anim.SetTrigger("Boss2Idle");
                  
                }
                break;
            case -1.76f:
            case -0.88f:
            case 0.88f:
            case 1.76f:
                if (time >= 56f && anim.GetCurrentAnimatorStateInfo(0).IsName("Boss2_Idle"))
                {
                    duration += Time.deltaTime;
                    if (duration >= 4f)
                    {
                        anim.SetTrigger("Boss2_Atk2");
                        duration = 0f;
                    }
                  
                    //yield return new WaitForSeconds(1f);
                    anim.SetTrigger("Boss2Idle");
                }
                break;
            default:
               
                break;
        }

    }
}


        

