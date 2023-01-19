using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClone : MonoBehaviour
{
    public GameObject player;
    public GameObject[] clone;
    List<Vector3> wayPoints1 = new List<Vector3>();
    List<Vector3> wayPoints2 = new List<Vector3>();
    List<Vector3> wayPoints3 = new List<Vector3>();
    Vector3 currPosition;
    int wayPointIndex = 0;
    private float speed = 5f;
    float time;
    float countTime;
    bool clone1, clone2, clone3 = false;
    bool lastWayPoint1, lastWayPoint2, lastWayPoint3 = false;
    int cloneNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        clone[0].SetActive(false);
        clone[1].SetActive(false);
        clone[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        countTime += Time.deltaTime;
        if (clone1 == false)
        {
            if (time >= 3)
            {
                wayPoints1.Add(player.gameObject.transform.position);
                //Debug.Log(points[i].x + " " + points[i].z);
                time = 0;
            }
        }
        else if (clone1 == true && clone2 == false)
        {
            if (time >= 3)
            {
                wayPoints2.Add(player.gameObject.transform.position);
                //Debug.Log(points[i].x + " " + points[i].z);
                time = 0;
            }
        } 
        else if (clone1 == true && clone2 == true && clone3 == false)
        {
            if (time >= 3)
            {
                wayPoints3.Add(player.gameObject.transform.position);
                //Debug.Log(points[i].x + " " + points[i].z);
                time = 0;
            }
        }

        if (clone1 == true)
        {
            clone[0].SetActive(true);
            if (lastWayPoint1 == false)
            {
                wayPoints1.Add(player.gameObject.transform.position);
                player.gameObject.transform.position = new Vector3(0, 1, 0);
                lastWayPoint1 = true;
            }
            if (wayPointIndex != wayPoints1.Count)
            {
                currPosition = clone[0].transform.position;

                float step = speed * Time.deltaTime;
                clone[0].transform.position = Vector3.MoveTowards(currPosition, wayPoints1[wayPointIndex], step);
                if (Vector3.Distance(wayPoints1[wayPointIndex], currPosition) == 0f)
                    wayPointIndex++;
            }
        }

        if (clone2 == true)
        {
            clone[1].SetActive(true);
            if (lastWayPoint2 == false)
            {
                wayPoints2.Add(player.gameObject.transform.position);
                player.gameObject.transform.position = new Vector3(0, 1, 0);
                lastWayPoint2 = true;
            }
            if (wayPointIndex != wayPoints2.Count)
            {
                currPosition = clone[1].transform.position;

                float step = speed * Time.deltaTime;
                clone[1].transform.position = Vector3.MoveTowards(currPosition, wayPoints2[wayPointIndex], step);
                if (Vector3.Distance(wayPoints2[wayPointIndex], currPosition) == 0f)
                    wayPointIndex++;
            }
        }

        if (clone3 == true)
        {
            clone[2].SetActive(true);
            if (lastWayPoint3 == false)
            {
                wayPoints3.Add(player.gameObject.transform.position);
                player.gameObject.transform.position = new Vector3(0, 1, 0);
                lastWayPoint3 = true;
            }
            if (wayPointIndex != wayPoints3.Count)
            {
                currPosition = clone[2].transform.position;

                float step = speed * Time.deltaTime;
                clone[2].transform.position = Vector3.MoveTowards(currPosition, wayPoints3[wayPointIndex], step);
                if (Vector3.Distance(wayPoints3[wayPointIndex], currPosition) == 0f)
                    wayPointIndex++;
            }
        }
    }


    public void goBackButton()
    {
        wayPointIndex = 0;
        time = 0;
        if (clone1 == false && clone2 == false && clone3 == false)
            clone1 = true;
        else if (clone1 == true && clone2 == false && clone3 == false)
            clone2 = true;
        else if (clone1 == true && clone2 == true && clone3 == false)
            clone3 = true;
        clone[0].transform.position = new Vector3(0, 1, 0);
        clone[1].transform.position = new Vector3(0, 1, 0);
        clone[2].transform.position = new Vector3(0, 1, 0);
        Debug.Log("1" + clone1);
        Debug.Log("2" + clone2);
        Debug.Log("3" + clone3);
    }
}

