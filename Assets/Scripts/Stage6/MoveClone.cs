using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClone : MonoBehaviour
{
    public GameObject player;
    List<Vector3> wayPoints = new List<Vector3>();
    Vector3 currPosition;
    int wayPointIndex = 0;
    private float speed = 3f;
    float time;
    float countTime;

    SavePlayerWay savePlayerWay;
    // Start is called before the first frame update
    void Start()
    {
        savePlayerWay = GetComponent<SavePlayerWay>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        countTime += Time.deltaTime;
        if (time >= 5)
        {
            wayPoints.Add(player.gameObject.transform.position);
            //Debug.Log(points[i].x + " " + points[i].z);
            time = 0;
            
        }
        if (countTime >= 6)
        {
            currPosition = this.gameObject.transform.position;


            float step = speed * Time.deltaTime;
            this.gameObject.transform.position = Vector3.MoveTowards(currPosition, wayPoints[wayPointIndex], step);
            Debug.Log(wayPoints);
            if (Vector3.Distance(wayPoints[wayPointIndex], currPosition) == 0f)
                wayPointIndex++;
        }       
    }

}

