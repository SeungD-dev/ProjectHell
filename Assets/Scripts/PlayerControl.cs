using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    
    public Vector3 player_Pos;
   
    private Rigidbody rb;
    
    GameObject jumpBtn, leftBtn, rightBtn;

    bool jumpAllowed = true;
    bool isJumping = false;

    private Vector3 MoveDir;



    // Start is called before the first frame update
    void Start()
    {
        jumpBtn = GameObject.Find("JumpButton");
        leftBtn = GameObject.Find("LButton");
        rightBtn = GameObject.Find("RButton");
      
       
        rb = GetComponent<Rigidbody>();
        MoveDir = Vector3.zero;



    }

    // Update is called once per frame
    void Update()
    {
        player_Pos = gameObject.transform.position;

        if(jumpAllowed == false)
        {
            jumpBtn.GetComponent<Button>().interactable = true;
        }
        if (jumpAllowed == true)
        {
            jumpBtn.GetComponent<Button>().interactable = false;
        }


    }

    public void JumpTouched()
    {
        if (!jumpAllowed)
        {
            jumpAllowed = true;
           
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             
            gameObject.layer = 7;

        }
       
    }

    public void LButtonDown()
    {
        if(gameObject.transform.position.x !=-1.76)
        {
            transform.Translate(-0.88f, 0, 0);
        }
        else if(gameObject.transform.position.x > 1.76)
        {
            transform.Translate(0, 0, 0);
        }
    }
    public void RButtonDown()
    {
        if (gameObject.transform.position.x != 1.76)
        {
            transform.Translate(0.88f, 0, 0);
        }
        else if (gameObject.transform.position.x < 1.76)
        {
            transform.Translate(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpAllowed = false;
        }
    }
}
