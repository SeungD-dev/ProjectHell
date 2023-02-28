using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBtnMove : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    bool left, right, up, down = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            Player.transform.position += new Vector3(Speed * Time.deltaTime * -1, 0, 0);
            this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (right)
        {
            Player.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (up)
        {
            Player.transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (down)
        {
            Player.transform.position += new Vector3(0, 0, Speed * Time.deltaTime * -1);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void UpBtnUp()
    {
        up = true;
    }

    public void DownBtnUp()
    {
        down = true;
    }

    public void RightBtnUp()
    {
        right = true;
    }

    public void LeftBtnUp()
    {
        left = true;
    }

    public void UpBtnDown()
    {
        up = false;
    }

    public void DownBtnDown()
    {
        down = false;
    }

    public void RightBtnDown()
    {
        right = false;
    }

    public void LeftBtnDown()
    {
        left = false;
    }

}
