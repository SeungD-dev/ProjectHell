using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{

   // public Material[] ballColor;
    
    //public int index;
    AttackEvent attackEvent;
    //Renderer rd;
    //Material[] mat;
    public Material[] mats = new Material[4];
    private Renderer ballRender;
    public Material normal, red, green, blue;

    /*static BallColor instance = null;
    public static BallColor Instance
    {
        get
        {
            if (null == instance) return null;
            return instance;
        }
    }*/

    private void Awake()
    {
        /*if (null == instance) instance = this;
        ballColor = Resources.LoadAll<Material>("Material/BallColor");*/
    }

    void Start()
    {
       /* Renderer rd = this.GetComponent<MeshRenderer>();
        Material[] mat = rd.sharedMaterials;*/
        attackEvent = FindObjectOfType<AttackEvent>();
        mats = ballRender.sharedMaterials;
    }

    
    void Update()
    {
        if (attackEvent.bc == AttackEvent.ballColor.normal)
        {
            //mat[0] = BallColor.Instance.ballColor[index];
            mats[0] = normal;
           
        }
        if (attackEvent.bc == AttackEvent.ballColor.red)
        {
            // mat[1] = BallColor.Instance.ballColor[index];
            mats[1] = red;
          

        }

        if (attackEvent.bc == AttackEvent.ballColor.green)
        {
            //mat[2] = BallColor.Instance.ballColor[index];
            mats[2] = green;
          
        }
        if (attackEvent.bc == AttackEvent.ballColor.blue)
        {
            // mat[3] = BallColor.Instance.ballColor[index];
            mats[3] = blue;
           
        }
    }
}
