using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis_Status : MonoBehaviour
{
    private int AnubisHP = 5;
    private float AnubisHPtime = 90;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        AnubisHPtime -= Time.deltaTime;

        if(AnubisHP <= 0)
        {
            Debug.Log("아누비스 죽음");
        }
        if(AnubisHPtime <= 0)
        {
            Debug.Log("아누비스 죽음");
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if(AnubisHP >= 4)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                Debug.Log("아누비스 체력 : " + AnubisHP);
            }
            else if(AnubisHP <= 3)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                Debug.Log("아누비스 체력 : " + AnubisHP);
            }
            if(AnubisHP == 0)
            {
                Destroy(other.gameObject);
               
            }
        }
    }
}
