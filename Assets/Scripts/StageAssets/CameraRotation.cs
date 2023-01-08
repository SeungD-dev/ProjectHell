using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5)
        {
            transform.localEulerAngles = new Vector3(33.5f, 0, 180);
        }
    }
}
