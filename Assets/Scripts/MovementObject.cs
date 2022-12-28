using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 10;

    void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if ( x != 0 || y != 0)
        {
            transform.position += new Vector3(-y, 0, x) * moveSpeed * Time.deltaTime;
        }
    }
}
