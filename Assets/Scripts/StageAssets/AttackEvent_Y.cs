using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent_Y : MonoBehaviour
{
    public GameObject absorption;
    public GameObject absorbBtn;
    public SpriteRenderer absorptionSprite;


    private float countTime;

    public bool Absorbmode, Attackmode = false, Shootmode = false;

    private float absorbTime = 0.1f;

    enum asbColor { normal, red, blue, green }
    public enum ballColor { normal, red, blue, green }
    public ballColor bc = ballColor.normal;
    public int r, g, b;

    asbColor asb;

    PlayerControl_Y playerControl;
    AttackManager_Y attackManager;




    // Start is called before the first frame update
    void Start()
    {
        absorption = GameObject.Find("Absorption");
        absorbBtn = GameObject.Find("AbsorbButton");

        playerControl = FindObjectOfType<PlayerControl_Y>();
        attackManager = FindObjectOfType<AttackManager_Y>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = playerControl.player_Pos + new Vector3(0, 0.4f, -2.5f);
        transform.localPosition = playerControl.player_Pos + new Vector3(0, +0.16f, +0.33f);
        countTime += Time.deltaTime;

        if (countTime >= absorbTime)
        {
            AbsorbColorTransparency();

        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (gameObject.activeInHierarchy)
        {
            if (asb == asbColor.normal)
            {
                bc = ballColor.normal;
                if (col.gameObject.CompareTag("Note_R") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.red;
                    bc = ballColor.red;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                }
                if (col.gameObject.CompareTag("Note_B") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.blue;
                    bc = ballColor.blue;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                }
                if (col.gameObject.CompareTag("Note_G") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.green;
                    bc = ballColor.green;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;

                }

                if (col.gameObject.CompareTag("Note_Fake"))
                {
                    Destroy(col.gameObject);
                    playerControl.Hurt();
                    AbsorbColorTransparency();
                    Absorbmode = false;
                }

                if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    g = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    r = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    b = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
            }

            //Ã¹ Èí¼ö°¡ »¡°£»öÀÏ ¶§
            if (asb == asbColor.red)
            {
                bc = ballColor.red;
                if (asb == asbColor.red && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = true;
                    Debug.Log("°ø°Ý¸ðµå È°¼ºÈ­");
                    asb = asbColor.red;
                    bc = ballColor.red;
                    r = 1;
                    b = 0;
                    g = 0;
                }
                else if (asb == asbColor.red && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.blue;
                    bc = ballColor.blue;
                }
                else if (asb == asbColor.red && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.green;
                    bc = ballColor.green;
                }
                else if (col.gameObject.CompareTag("Note_Fake"))
                {
                    Destroy(col.gameObject);
                    playerControl.Hurt();
                    AbsorbColorTransparency();
                    Absorbmode = false;
                }

                if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    g = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    r = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    b = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
            }
            
            //Ã¹ Èí¼ö°¡ ÆÄ¶õ»öÀÏ ¶§
            else if (asb == asbColor.blue)
            {
                bc = ballColor.blue;
                if (asb == asbColor.blue && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = true;
                    Debug.Log("°ø°Ý¸ðµå È°¼ºÈ­");
                    asb = asbColor.blue;
                    bc = ballColor.blue;
                    r = 0;
                    b = 1;
                    g = 0;
                }
                else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.red;
                    bc = ballColor.red;
                }
                else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.green;
                    bc = ballColor.green;
                }
                else if (col.gameObject.CompareTag("Note_Fake"))
                {
                    Destroy(col.gameObject);
                    playerControl.Hurt();
                    AbsorbColorTransparency();
                    Absorbmode = false;
                }

                if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    g = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    r = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    b = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
            }

            //Ã¹ Èí¼ö°¡ ÃÊ·Ï»öÀÏ ¶§
            else if (asb == asbColor.green)
            {
                bc = ballColor.green;
                if (asb == asbColor.green && col.gameObject.CompareTag("Note_G") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = true;
                    Debug.Log("°ø°Ý¸ðµå È°¼ºÈ­");
                    asb = asbColor.green;
                    bc = ballColor.green;
                    r = 0;
                    g = 1;
                    b = 0;
                }
                else if (asb == asbColor.green && col.gameObject.CompareTag("Note_R") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.red;
                    bc = ballColor.red;
                }
                else if (asb == asbColor.blue && col.gameObject.CompareTag("Note_B") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    Attackmode = false;

                    asb = asbColor.blue;
                    bc = ballColor.blue;
                }
                else if (col.gameObject.CompareTag("Note_Fake"))
                {
                    Destroy(col.gameObject);
                    playerControl.Hurt();
                    AbsorbColorTransparency();
                    Absorbmode = false;
                }

                if (col.gameObject.CompareTag("Note_BG") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    g = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BR") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    r = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
                if (col.gameObject.CompareTag("Note_BB") && Absorbmode == true)
                {
                    Destroy(col.gameObject);
                    asb = asbColor.normal;
                    bc = ballColor.normal;
                    AbsorbColorTransparency();
                    Debug.Log("Èí¼öµÊ");
                    Absorbmode = false;
                    b = 1;
                    Shootmode = true; Attackmode = true;
                    attackManager.ShootAttack();
                }
            }
        }
    }


    public void AbsorbButtonDown()
    {
        countTime = 0;
        StartCoroutine("AttackCooldown");
        AbsorbUncolorTrasparency();

        if (Attackmode == false)
        {
            Absorbmode = true;
        }
        if (Attackmode == true)
        {
            Debug.Log("¹ß»ç ÁØºñ");
            Shootmode = true;
        }

        if (Attackmode == true && Shootmode == true)
        {
            attackManager.ShootAttack();

            Absorbmode = false;
            asb = asbColor.normal;
        }
    }

    public void AbsorbColorTransparency()
    {
        GetComponent<MeshRenderer>().materials[0].color = new Color(0, 0, 0, 0f);
        //absorptionSprite.color = new Color(0, 100, 100, 0f);
        absorption.GetComponent<SphereCollider>().enabled = false;
    }

    public void AbsorbUncolorTrasparency()
    {
        GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0, 1f);
        //absorptionSprite.color = new Color(0, 0, 0, 1f);
        absorption.GetComponent<SphereCollider>().enabled = true;
    }

    IEnumerator AttackCooldown()
    {
        absorbBtn.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        absorbBtn.SetActive(true);
    }
}
