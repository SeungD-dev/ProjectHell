using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject2_1_Y : MonoBehaviour
{
    public GameObject ViewCamera = null;
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 10;


    void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0)
        {
            transform.position += new Vector3(-y, 0, x) * moveSpeed * Time.deltaTime;
        }
        if (ViewCamera != null)
        {
            Vector3 direction = new Vector3(6, 9, 0); //(Vector3.up * 2 + Vector3.back) * 2; 
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position + direction, Color.red);
            if (Physics.Linecast(transform.position, transform.position + direction, out hit))
            {
                ViewCamera.transform.position = hit.point + new Vector3(0, 1, 0);
            }
            else
            {
                ViewCamera.transform.position = transform.position + direction;
            }
            ViewCamera.transform.LookAt(transform.position);
            ViewCamera.transform.eulerAngles = new Vector3(45, -90, 0);
        }
    }
}
