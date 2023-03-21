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
    public GameObject anubis_roar, hitGround;

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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 68.8 && asdf == true) //time >= 68.8
        {
            anim.SetTrigger("AnubisAtk");
            anubis_roar.SetActive(true);
            //PlaySound("roar");
        }
        if(time >= 70) //time>= 70
        {
            Debug.Log("dsa");
            hitGround.SetActive(true);
          
            //PlaySound("hitGround");
        }

        if (time >= 69) //time >= 69
        {
            asdf = false;
        }
        //Debug.Log("¾Æ´©ºñ½º Èý"+ anubis_Status.isHit);

        if(anubis_Status.isHit == true)
        {
            anim.SetTrigger("AnubisHit");
        
            anubis_Status.isHit = false;

        }
       

        if(anubis_Status.AnubisHP >= 3 && anubis_Status.isHit == true)
        {
            anim.SetTrigger("AnubisHit");
            anim.SetBool("AnubisLow", true);
            anubis_Status.isHit = false;
        }
        if (anubis_Status.isHit == false)
        {
            anim.SetTrigger("AnubisIdle");
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
