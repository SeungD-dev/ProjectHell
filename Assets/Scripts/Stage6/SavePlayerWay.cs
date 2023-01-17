using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerWay : MonoBehaviour
{
    float time;
    public List<Vector3> points = new List<Vector3>();

    int i;
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5)
        {           
            points.Add(this.transform.position);
            //Debug.Log(points[i].x + " " + points[i].z);
            i++;
            time = 0;
        }
    }
}
