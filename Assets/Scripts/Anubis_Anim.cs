using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Anubis_Anim : MonoBehaviour
{
    GameManager gameManager;

    public Animator anim;
    public Animator boom_anim;
    float time;
    SpriteRenderer sr;

    GameObject boom;
    public AudioSource anubis_roar, hitGround;

    bool asdf = true, boomSound = false;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = gameObject.GetComponentInChildren<Animator>();
        boom_anim = gameObject.GetComponentInChildren<Animator>();
        boom = GameObject.Find("boom");
        sr = boom.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.3 && asdf == true)
        {
           
            anim.SetTrigger("AnubisAtk");
            anubis_roar.Play();
            
          




        }
        if(time == 2.5)
        {
            hitGround.Play();
        }

        if (time >= 2.4)
        {
           
            asdf = false;
           

        }
       
       
       
        
    }
}
