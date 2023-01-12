using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail_Y : MonoBehaviour
{
    BossRandomMove_Y brm;
    GameObject prefabToInstantiate;

    public float slashSpeed = 8f;
    public float duration = 5f;

    public GameObject[] slash;

    private float time;  

    void Start()
    {
        brm = FindObjectOfType<BossRandomMove_Y>();
        InvokeRepeating("BossSlash", 3, duration);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "SwordTrail")
        {
            this.gameObject.transform.localPosition += Vector3.back * slashSpeed * Time.deltaTime;
        }
        else if (this.gameObject.tag == "SwordTrail_Vertical")
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
                Instantiate(prefabToInstantiate, new Vector3(0, 0.5f, 7), Quaternion.identity);
            }
            else if (brm.newX == -1.7f || brm.newX == -0.8f || brm.newX == 0.8f || brm.newX == 1.7f)
            {
                prefabToInstantiate = slash[1];
                Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            }

            
        }
    }

}
