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



    void Start()
    {
        brm = FindObjectOfType<BossRandomMove>();
    }

    // Update is called once per frame
    void Update()
    {
       if(brm.newX == 0f)
        {
            prefabToInstantiate = slash[0];
        }
        else
        {
            prefabToInstantiate = slash[1];
        }

        Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);

        if(brm.newX == 0f)
        {
            slash[0].transform.localPosition += Vector3.back * slashSpeed * Time.deltaTime;
        }
        else
        {
            slash[1].transform.localPosition += Vector3.back * slashSpeed * Time.deltaTime;
        }
    }
}
