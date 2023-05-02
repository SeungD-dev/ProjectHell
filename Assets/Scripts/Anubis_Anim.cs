using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Anubis_Anim : MonoBehaviour
{
    GameManager gameManager;

    public Animator anim;
   
   
    float time;
   

   
    public AudioSource audioSource;
    //public AudioClip anubis_roar, hitGround;

    public bool asdf = true, boomSound = false;
    public bool timeStop = true;
    public GameObject anubis_roar, hitGround;
    bool isLowHP = false;

    Anubis_Status anubis_Status;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = gameObject.GetComponentInChildren<Animator>();
       
       
       
        anubis_roar.SetActive(false);
        hitGround.SetActive(false);
        anubis_Status = FindObjectOfType<Anubis_Status>();
        anim.SetBool("AnubisLow", false);
        anim.SetBool("Anubis_IsAtk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            time += Time.deltaTime;
        }
   
        if (time >= 73.8 && asdf == true) //time >= 68.8
        {
            anim.SetTrigger("AnubisAtk");
            anubis_roar.SetActive(true);
            //PlaySound("roar");
        }
        if(time >= 75) //time>= 70
        {
            Debug.Log("dsa");
            hitGround.SetActive(true);
          
            //PlaySound("hitGround");
        }

        if (time >= 74) //time >= 69
        {
            anim.SetBool("Anubis_IsAtk", false);
            asdf = false;
        }
        //Debug.Log("¾Æ´©ºñ½º Èý"+ anubis_Status.isHit);

     

       
            AnimationUpdate();
     
       

       
    }
    void AnimationUpdate()
    {
        if (anubis_Status.isHit == true)
        {
            anim.SetTrigger("AnubisHit");

            anubis_Status.isHit = false;

        }
        if(anubis_Status.AnubisHP >= 3)
        {
            anim.SetBool("AnubisIdleFull", true);
            anim.SetBool("AnubisLowIdle", false);
        }
        if(anubis_Status.AnubisHP <= 3)
        {
            anim.SetBool("AnubisIdleFull", false);
            anim.SetBool("AnubisLowIdle", true);
        }


        /*if (anubis_Status.AnubisHP <= 3 && anubis_Status.isHit == true)
        {
            anim.SetTrigger("AnubisHit");
            //anim.SetBool("AnubisLowIdle", true);
            anubis_Status.isHit = false;
        }*/
        if (anubis_Status.isHit == false && anim.GetBool("AnubisIdleFull") == true)
        {
            anim.SetTrigger("AnubisIdle");
        }
        if(anubis_Status.isHit == false && anim.GetBool("AnubisLowIdle") == true)
        {
            anim.SetTrigger("AnubisLow");
        }
    }
   

    /*void PlaySound(string action)
    {
        switch (action)
        {
            case "roar":
                audioSource.clip = anubis_roar;
                break;
            case "hitGround":
                audioSource.clip = hitGround;
                break;
        }
        audioSource.Play();
    }*/
}
