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


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boss2_Status = FindObjectOfType<Boss2_Status>();
        brm = FindObjectOfType<BossRandomMove_Y>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        PositionAnimUpdate();
        AnimationUpdate();
    }

    void AnimationUpdate()
    {
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
        if (anim.GetBool("Boss2_IsAtk1") == false)
        {
            anim.SetTrigger("Boss2Idle");
        }
        if(anim.GetBool("Boss2_IsAtk2") == false)
        {
            anim.SetTrigger("Boss2Idle");
        }
        
        if (time >= 56.2)
        {
            if(brm.newX == 0f && anim.GetBool("Boss2_IsAtk1") == true)
            {
                anim.SetTrigger("Boss2_Atk1");
            }
            else if(brm.newX == -1.76f || brm.newX == -0.88f || brm.newX == 0.88f || brm.newX == 1.76f)
            {
                if(anim.GetBool("Boss2_IsAtk2")==true)
                anim.SetTrigger("Boss_Atk2");
            }
        }

    }

    void PositionAnimUpdate()
    {
        if(time >= 56.2)
        {
            if (brm.newX == 0f)
            {
                anim.SetBool("Boss2_IsAtk1",true);
                anim.SetBool("Boss2_IsAtk2", false);
            }
            else if (brm.newX == -1.76f || brm.newX == -0.88f || brm.newX == 0.88f || brm.newX == 1.76f)
            {
                anim.SetBool("Boss2_IsAtk1", false);
                anim.SetBool("Boss2_IsAtk2", true);
            }
        }
    }
}
