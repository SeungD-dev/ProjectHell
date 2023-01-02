using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    GameObject camera;

    void Start()
    {
        camera = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = camera.transform.position;
        position.x = player.transform.position.x + 8;
        position.y = player.transform.position.y + 16;
        position.z = player.transform.position.z ;
        camera.transform.position = position;
    }
}
