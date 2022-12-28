using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Anubis_Anim : MonoBehaviour
{
    GameManager gameManager;

    public Animator anim;
    float time;
    SpriteRenderer sr;

    GameObject boom;

    bool asdf = true;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = gameObject.GetComponentInChildren<Animator>();
        boom = GameObject.Find("boom");
        sr = boom.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 8.797 && asdf == true)
        {
            anim.SetTrigger("kaboom");
           
            anim.SetBool("AnubisIdle", false);
            anim.SetBool("Anubis_IsAttack", true);
           
           
           
           
           
        }
        if (time >= 8.8)
        {
            asdf = false;
            anim.SetBool("Anubis_IsAttack", false);
            anim.SetBool("AnubisIdle", true);


        }
       
       
        
    }
}
