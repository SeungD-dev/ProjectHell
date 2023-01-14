using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackRandomSpawn : MonoBehaviour
{
    public GameObject rangeObject;
    public GameObject attackPrefab;
    public Transform player;
    BoxCollider rangeCollider;
    public  bool isAttackDestroyed = true;
   
    private void Update()
    {
        if (isAttackDestroyed == true)
        {
            StartCoroutine(RandomRespawn());

            isAttackDestroyed = false;

        }
    }



    IEnumerator RandomRespawn()
    {
       
        yield return new WaitForSeconds(2f);
            

            GameObject instantPrefab = Instantiate(attackPrefab, Return_RandomPosition(), Quaternion.identity);
       
        instantPrefab.GetComponent<Renderer>().material.color = ColorManager.colors[ColorManager.randomColorIndex];
       
        
       
        ColorManager.usedColors.Add(ColorManager.colors[ColorManager.randomColorIndex]);
      
        Debug.Log("randomRespawn" + ColorManager.randomColorIndex);
            
            isAttackDestroyed = false;
      

        
    }

    private void Awake()
    {
       
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }
  


    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;

    }
}
