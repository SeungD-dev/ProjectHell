using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bossAttack;
    public Transform bossAttackAppear;
    int counter;
    private void OnTriggerEnter(Collider other)
    {
        counter = Random.Range(0, 10);
        if(counter >= 8)
        {
            GameObject t_attack = Instantiate(bossAttack, bossAttackAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
        }
        Debug.Log(counter);
    }
}
