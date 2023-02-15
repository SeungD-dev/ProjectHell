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
    public float[] possibleXValues = { -1.7f, -0.8f, 0, 0.8f, 1.7f };

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
                Instantiate(prefabToInstantiate, new Vector3(0, 0.3f, 7), Quaternion.identity);
            }
            else if (brm.newX == -1.7f || brm.newX == -0.8f || brm.newX == 0.8f || brm.newX == 1.7f)
            {
                prefabToInstantiate = slash[1];
                Instantiate(prefabToInstantiate, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            }
        }
    }

    void RandomBossSlash()
    {
        prefabToInstantiate = slash[1];
        Instantiate(prefabToInstantiate, new Vector3(possibleXValues[Random.Range(0, possibleXValues.Length)], 0, 7f), Quaternion.identity);
    }
}
