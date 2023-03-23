using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail_Y : MonoBehaviour
{
    BossRandomMove_Y brm;
    GameObject prefabToInstantiate;

    public float slashSpeed = 8f;
    public float duration;

    public GameObject[] slash;
    public Transform boss;
    public float[] possibleXValues = { -1.76f, -0.88f, 0, 0.88f, 1.76f };

    public float time = 0;
    void Start()
    {
        brm = FindObjectOfType<BossRandomMove_Y>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 55 && time < 99)
        {
            duration += Time.deltaTime;
            if(duration >= 4f)
            {
                BossSlash();
                duration = 0;
            }
        }
        if(time >= 99)
        {
            duration += Time.deltaTime;
            if(duration >= 0.5f)
            {
                RandomBossSlash();
                duration = 0;
            }
        }
        if (this.gameObject.tag == "SwordTrail" || this.gameObject.tag == "SwordTrail_Vertical")
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
                Instantiate(prefabToInstantiate, new Vector3(0, 0.3f, 7), Quaternion.identity);
            }
            else if (brm.newX == -1.76f || brm.newX == -0.88f || brm.newX == 0.88f || brm.newX == 1.76f)
            {
                prefabToInstantiate = slash[1];
                //Instantiate(prefabToInstantiate, transform.position + new Vector3(0, -2.4f, -0.5f), prefabToInstantiate.transform.rotation);
                Instantiate(prefabToInstantiate, new Vector3(brm.newX+ -0.225f, -0.24f, 6.5f), prefabToInstantiate.transform.rotation);
            }
        }
    }

    void RandomBossSlash()
    {
        prefabToInstantiate = slash[1];
        Instantiate(prefabToInstantiate, new Vector3(possibleXValues[Random.Range(0, possibleXValues.Length)] + -0.225f, 0, 7f), prefabToInstantiate.transform.rotation);
    }
}
