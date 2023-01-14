using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform follow;
    [SerializeField] float m_Speed;
    [SerializeField] float m_MaxRayDist = 1;
    [SerializeField] float m_Zoom = 3f;
    RaycastHit m_Hit;
    Vector2 m_Input;
    Vector3 cameraPosition;

    void Start()
    {
    }
    private void Update()
    {
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            m_Input.x = Input.GetAxis("Mouse X");
            m_Input.y = Input.GetAxis("Mouse Y");

            if (m_Input.magnitude != 0)
            {
                Quaternion q = follow.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x + m_Input.y * m_Speed, q.eulerAngles.y + m_Input.x * m_Speed, q.eulerAngles.z);
                follow.rotation = q;
            }
        }
    }


    public void LateUpdate()
    {
        Rotate();
    }
}
