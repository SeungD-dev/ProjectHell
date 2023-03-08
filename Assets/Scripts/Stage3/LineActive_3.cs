using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive_3 : MonoBehaviour
{
    PlayerControl playerControl;
    public float time;
    public GameObject bind;
    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        bind.SetActive(false);
        GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(false);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0)
        {
            GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
        }
        if (time >= 38.5)
        {
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            bind.SetActive(true);
            playerControl.flip = true;
            playerControl.jumpCC = true;
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(true);
        }
        if(time>= 48.5)
        {
            bind.SetActive(false);
            playerControl.flip = false;
            playerControl.jumpCC = false;
        }
    }
}
