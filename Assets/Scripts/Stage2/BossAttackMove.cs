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
    int ClearCount = 0;
    ColorChange colorChange;
    bool isDestroyed = false;
   

    void Awake()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        agent = GetComponent<NavMeshAgent>();
        colorChange = FindObjectOfType<ColorChange>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = FindObjectOfType<MiniGame2_PlayerHP>();
       
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        agent.SetDestination(player.transform.position);
        agent.acceleration = Mathf.Lerp(agent.acceleration, 200f, Time.deltaTime);

        if(isDestroyed == true)
        {
            ClearCount++;
            Debug.Log("클리어 카운트: " + ClearCount);
            isDestroyed = false;
        }

        if(ClearCount == 5)
        {
            ars.StopAllCoroutines();
            colorChange.StopAllCoroutines();


        }


      

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

            isDestroyed = true;
            Debug.Log("아아아아ㅏ아아");
           
            Destroy(this.gameObject);
           
            ars.isAttackDestroyed = true;
           

            
        }
       
       


    }
  
}
