using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackEvent : MonoBehaviour
{
    public GameObject absorption;
    public GameObject absorbBtn;
    public AudioSource SwordSound;

    private float countTime;

    public bool  Absorbmode, Attackmode = false,Shootmode = false , startAtk;

    private float absorbTime = 0.1f;

    enum asbColor { normal, red, blue , green}
    public enum ballColor {normal,red, blue, green }
    public ballColor bc = ballColor.normal;
    public int r, g, b;

    asbColor asb;

    PlayerControl playerControl;
    AttackManager attackManager;

    // Start is called before the first frame update
    void Start()
    {
        absorption = GameObject.Find("Absorption");
        absorbBtn = GameObject.Find("AbsorbButton");

        playerControl = FindObjectOfType<PlayerControl>();
        attackManager = FindObjectOfType<AttackManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = playerControl.player_Pos + new Vector3(0, +0.16f, +0.33f);
        countTime += Time.deltaTime;

        if(countTime >= absorbTime)
        {
            absorption.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {

        if (asb == asbColor.normal)
        {
            bc = ballColor.normal;
            if (col.gameObject.CompareTag("Note_R") && Absorbmode == true)
            {
                playerControl.tutorial = "second";
                AttackNormal(col);
                asb = asbColor.red;
                bc = ballColor.red;
            }
            if (col.gameObject.CompareTag("Note_B") && Absorbmode == true)
            {
                playerControl.tutorial = "second";
                AttackNormal(col);
                asb = asbColor.blue;
                bc = ballColor.blue;
            }
            if (col.gameObject.CompareTag("Note_G") && Absorbmode == true)
            {
                playerControl.tutorial = "second";
                AttackNormal(col);
                asb = asbColor.green;
                bc = ballColor.green;
            }
            if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 1; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
            {
                AttackOk(col);
                r = 1; g = 0; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 0; b = 1;
            }
        }
        //첫 흡수가 빨간색일 때
        if (asb == asbColor.red)
        {
            bc = ballColor.red;
            if (asb == asbColor.red && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
            {
                playerControl.tutorial = "third";
                AttackOk(col);
                r = 1; b = 0; g = 0;
            }
            else if (asb == asbColor.red && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.blue;
                bc = ballColor.blue;
            }
            else if (asb == asbColor.red && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.green;
                bc = ballColor.green;
            }
            if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 1; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
            {
                AttackOk(col);
                r = 1; g = 0; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 0; b = 1;
            }
        }
        //첫 흡수가 파란색일 때
        else if (asb == asbColor.blue)
        {
            bc = ballColor.blue;
            if (asb == asbColor.blue && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
            {
                playerControl.tutorial = "third";
                AttackOk(col);
                r = 0; b = 1; g = 0;
            }
            else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.red;
                bc = ballColor.red;
            }
            else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.green;
                bc = ballColor.green;
            }
            if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 1; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
            {
                AttackOk(col);
                r = 1; g = 0; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 0; b = 1;
            }
        }
        //첫 흡수가 초록색일 때
        else if (asb == asbColor.green)
        {
            bc = ballColor.green;
            if (asb == asbColor.green && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
            {
                playerControl.tutorial = "third";
                AttackOk(col);
                r = 0; g = 1; b = 0;
            }
            else if (asb == asbColor.green && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.red;
                bc = ballColor.red;
            }
            else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
            {
                Destroy(col.gameObject);
                Attackmode = false;
                playerControl.tutorial = "second";
                asb = asbColor.blue;
                bc = ballColor.blue;
            }
            if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 1; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
            {
                AttackOk(col);
                r = 1; g = 0; b = 0;
            }
            if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
            {
                AttackOk(col);
                r = 0; g = 0; b = 1;
            }
        }
    }
    

    public void AbsorbButtonDown()
    {
        countTime = 0;
        StartCoroutine("AttackCooldown");
        absorption.GetComponent<SphereCollider>().enabled = true;

        if (Attackmode == false)
        {
            Absorbmode = true;
        }
        /*if(Attackmode == true)
        {
            Debug.Log("발사 준비");
            Shootmode = true;
        }*/

        if(Attackmode == true )//&& Shootmode == true)
        {
            Attackmode = false;
            Absorbmode = false;
            asb = asbColor.normal;
            bc = ballColor.normal;
            r = 0;
            g = 0;
            b = 0;
        }
    }

    void AttackNormal(Collider col)
    {
        Destroy(col.gameObject);
        absorption.GetComponent<SphereCollider>().enabled = false;
        Absorbmode = false;
    }

    void AttackOk(Collider col)
    {
        Destroy(col.gameObject);
        Attackmode = true;
        SwordSound.Play();
        asb = asbColor.normal;
        bc = ballColor.normal;
    }

    IEnumerator AttackCooldown()
    {
        absorbBtn.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        absorbBtn.SetActive(true);
    }
}