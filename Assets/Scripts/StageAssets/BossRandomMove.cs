using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomMove : MonoBehaviour
{
    public float[] possibleXValues = { -1.7f, -0.8f, 0f, 0.8f, 1.7f };
    public float duration = 2f;
    public float newX;
    

    
    void Start()
    {
        InvokeRepeating("MoveBoss", 0, duration);
    }

   

    private void MoveBoss()
    {
        newX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        iTween.MoveTo(gameObject, iTween.Hash("x", newX, "easeType", "easeInOutExpo", "loopType", "none", "time", duration));

        

    }
   


}
