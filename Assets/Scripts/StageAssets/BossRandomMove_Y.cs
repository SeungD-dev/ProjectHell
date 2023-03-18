using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomMove_Y : MonoBehaviour
{
    public float[] possibleXValues = { -1.76f, -0.88f, 0, 0.88f, 1.76f };
    public GameObject bossPos;
    public float newX;
    public float moveTime;
    public float time = 0;

    void Start()
    {
        //newX = possibleXValues[Random.Range(0, possibleXValues.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 55 && time < 99)
        {
            moveTime += Time.deltaTime;
            if (moveTime >= 4f)
            {
                newX = possibleXValues[Random.Range(0, possibleXValues.Length)];
                moveTime = 0;
            }
        }
        if(time >= 99)
        {
            newX = possibleXValues[2];
        }
        bossPos.transform.localPosition = Vector3.MoveTowards(bossPos.transform.localPosition, new Vector3(newX, 2.5f, 7), 0.01f);
    }
}
