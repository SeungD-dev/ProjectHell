using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomMove1 : MonoBehaviour
{
    public float[] possibleXValues = { -1.7f, -0.8f, 0, 0.8f, 1.7f };
    public float duration = 7f;
    public float newX;

    void Start()
    {
        InvokeRepeating("MoveBoss", 0, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveBoss()
    {
        newX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        iTween.MoveTo(gameObject, iTween.Hash("x", newX, "easeType", "easeInOutExpo", "loopType", "none", "time", duration));



    }
}
