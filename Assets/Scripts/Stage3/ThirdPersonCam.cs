using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform follow;
    
    void Start()
    {
    }
    void Update()
    {
        this.gameObject.transform.position = new Vector3(follow.position.x, 11, follow.position.z);
    }
}
