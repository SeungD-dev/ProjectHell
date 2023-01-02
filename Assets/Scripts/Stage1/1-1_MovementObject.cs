using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 10;
    public GameObject ViewCamera = null;

    void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if ( x != 0 || y != 0)
        {
            transform.position += new Vector3(-y, 0, x) * moveSpeed * Time.deltaTime;
        }
        if (ViewCamera != null)
        {
            Vector3 direction = (Vector3.up * 4 + Vector3.back) * 2;
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position + direction, Color.red);
            if (Physics.Linecast(transform.position, transform.position + direction, out hit))
            {
                ViewCamera.transform.position = hit.point;
            }
            else
            {
                ViewCamera.transform.position = transform.position + new Vector3(6, 9, 0);
            }
            ViewCamera.transform.LookAt(transform.position);
            ViewCamera.transform.eulerAngles = new Vector3(45, -90, 0);
        }
    }
}
