using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttackMove : MonoBehaviour
{
    NavMeshAgent agent;
   GameObject player;
   AttackRandomSpawn ars;
    MiniGame2_PlayerHP playerHP;
   
  
   

    void Awake()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = FindObjectOfType<MiniGame2_PlayerHP>();
       
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        agent.SetDestination(player.transform.position);
        agent.acceleration = Mathf.Lerp(agent.acceleration, 200f, Time.deltaTime);
      

    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            ars.isAttackDestroyed = true;
            playerHP.DecreaseHP(1);
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
