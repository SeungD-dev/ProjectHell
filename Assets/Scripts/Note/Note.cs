using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 5;
    //Vector3 target = new Vector3(0, 0.2f, -2.8f);

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, target, 0.01f);
        transform.localPosition += Vector3.back * noteSpeed * Time.deltaTime;
    }
}
