using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCurve : MonoBehaviour
{
    public GameObject note;
    public Transform[] waypoints;
    float speed = 7f;

    
   
    // Update is called once per frame
    void Update()
    {
        iTween.MoveTo(note, iTween.Hash(
            "path", waypoints,
            "time", speed,
            "easetype",iTween.EaseType.easeInOutQuad
            ));
    }
}
