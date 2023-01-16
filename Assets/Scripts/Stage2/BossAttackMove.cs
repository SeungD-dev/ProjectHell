using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttackMove : MonoBehaviour
{
    NavMeshAgent agent;
   GameObject player;
   AttackRandomSpawn ars;
   // Color[] colorChoices;
    //int colorNum;
    ColorChange cc;

   

    void Awake()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        cc = FindObjectOfType<ColorChange>();
       
        //this.gameObject.GetComponent<Renderer>().material.color = colorChoices[colorNum];
       
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            ars.isAttackDestroyed = true;
        }
       
       if(this.gameObject.GetComponent<Renderer>().material.color == cc.gameObject.GetComponent<Renderer>().material.color)
        {
            Destroy(this.gameObject);
            ars.isAttackDestroyed = true;
        }
       

    }
  
}
