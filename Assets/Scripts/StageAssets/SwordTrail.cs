using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour
{
    BossRandomMove brm;


    public float slashSpeed = 8f;
    private float time;
    public GameObject[] slash;
    GameObject prefabToInstantiate;
    public float duration = 7f;



    void Start()
    {
        brm = FindObjectOfType<BossRandomMove>();
        InvokeRepeating("BossSlash", 0, duration);

        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(this.gameObject.tag == "SwordTrail")
        {
            this.gameObject.transform.localPosition += Vector3.back * slashSpeed * Time.deltaTime;
        }
        else if(this.gameObject.tag == "SwordTrail_Vertical")
        {
            this.gameObject.transform.localPosition += Vector3.back * slashSpeed * Time.deltaTime;
        }
    }

    void BossSlash()
    {
        if (this.gameObject.tag == "Boss")
        {
            if (brm.newX == 0f)
            {
                prefabToInstantiate = slash[0];
            }
            else if(brm.newX == -1.7f || brm.newX == -0.8f || brm.newX == 0.8f || brm.newX == 1.7f)
            {
                prefabToInstantiate = slash[1];
            }

            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
        }
    }

}
