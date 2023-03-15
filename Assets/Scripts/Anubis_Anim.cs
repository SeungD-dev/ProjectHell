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
    public AudioSource audioSource;
    //public AudioClip anubis_roar, hitGround;

    public bool asdf = true, boomSound = false;
    public GameObject anubis_roar, hitGround;

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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.3 && asdf == true)
        {
            anim.SetTrigger("AnubisAtk");
            anubis_roar.SetActive(true);
            //PlaySound("roar");
        }
        if(time >= 3.5)
        {
            Debug.Log("dsa");
            hitGround.SetActive(true);
            //PlaySound("hitGround");
        }

        if (time >= 2.4)
        {
            asdf = false;
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
