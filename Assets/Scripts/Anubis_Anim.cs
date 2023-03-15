using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Anubis_Anim : MonoBehaviour
{
    GameManager gameManager;

    public Animator anim;
    public Animator boom_anim;
    //public Animator anubis_hit,anubis_idle,anubis_low;
    float time;
    SpriteRenderer sr;

    GameObject boom;
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
        boom_anim = gameObject.GetComponentInChildren<Animator>();
        boom = GameObject.Find("boom");
        sr = boom.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
        anubis_roar.SetActive(false);
        hitGround.SetActive(false);
        anubis_Status = FindObjectOfType<Anubis_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 23.8 && asdf == true) //time >= 68.8
        {
            anim.SetTrigger("AnubisAtk");
            anubis_roar.SetActive(true);
            //PlaySound("roar");
        }
        if(time >= 25) //time>= 70
        {
            Debug.Log("dsa");
            hitGround.SetActive(true);
            //PlaySound("hitGround");
        }

        if (time >= 24) //time >= 69
        {
            asdf = false;
        }

        /*if(anubis_Status.isHit == true)
        {
            anubis_hit.SetTrigger("AnubisHit");
        
            anubis_Status.isHit = false;

        }
       

        if(anubis_Status.AnubisHP >= 3 && anubis_Status.isHit == true)
        {
            anubis_hit.SetTrigger("AnubisHit");
            anubis_low.SetBool("AnubisLow", true);
            anubis_Status.isHit = false;
        }
        if (anubis_Status.isHit == false)
        {
            anubis_idle.SetTrigger("AnubisIdle");
        }*/
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
