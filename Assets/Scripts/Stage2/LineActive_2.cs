using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive_2 : MonoBehaviour
{
    public float time;
    public bool timeStop;
    private void Start()
    {
        timeStop = true;
        GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(false);
    }
    void Update()
    {
        /*if (!timeStop)
        {
            time += Time.deltaTime;
        }*/
        time += Time.deltaTime;
        if (time >= 0.5)
        {
            GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
        }
        if(time >= 56)
        {
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(true);
        }
    }
}
