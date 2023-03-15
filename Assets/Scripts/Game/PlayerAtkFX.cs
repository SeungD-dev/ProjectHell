using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAtkFX : MonoBehaviour
{

    public Animator atkFX;
    AttackEvent attackEvent;
    
    void Start()
    {
        attackEvent = FindObjectOfType<AttackEvent>();
        atkFX = gameObject.GetComponentInChildren<Animator>();
    }

   
    void Update()
    {
       
       
    }

    public void AbsorbButtonDown()
    {
        atkFX.SetTrigger("atkFX");
    }
}
