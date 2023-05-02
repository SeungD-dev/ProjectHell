using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BoomFX : MonoBehaviour
{
    public Animator anim;
    GameObject boom, boom1;
    SpriteRenderer sr;
    float time;
    bool startFX;
    public bool timeStop = true;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        boom = GameObject.Find("boom");
        boom1 = GameObject.Find("boom1");
        sr = boom.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
        startFX = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            time += Time.deltaTime;
        }
       
        if (time >= 73.8)
        {
            startFX = true;
        }
        if(time >= 75 && startFX == true)
        {
            anim.SetTrigger("bang");
            startFX = false;
            time = 0;
           
        }
    }
}
