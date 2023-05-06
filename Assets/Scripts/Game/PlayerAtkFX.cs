using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAtkFX : MonoBehaviour
{
    public Animator atkFX;
    
    void Start()
    {
        atkFX = gameObject.GetComponentInChildren<Animator>();
    }

    public void AbsorbButtonDown()
    {
        atkFX.SetTrigger("atkFX");
    }
}
