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
    Renderer rend;

   

    void Awake()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        cc = FindObjectOfType<ColorChange>();
        rend = GetComponent<Renderer>();
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
        var attackPrefab = gameObject.GetComponent<Renderer>();
        var focusLight = other.gameObject.GetComponent<Renderer>();
        
        if (attackPrefab.sharedMaterial.color == focusLight.sharedMaterial.color)
        {
            Destroy(this.gameObject);
            ars.isAttackDestroyed = true;
        }
       
       


    }
  
}
