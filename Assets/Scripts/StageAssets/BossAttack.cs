using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bossAttack;
    public Transform bossAttackAppear;
    int counter;
    public float attackSpeed = 5;

    void Update()
    {
        if(this.gameObject.tag == "BossAttack_Down")
        {
            transform.localPosition += Vector3.down * attackSpeed * Time.deltaTime;
        }
        if(this.gameObject.tag == "BossAttack_Up")
        {
            transform.localPosition += Vector3.up * attackSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "BossAttack")
        {
            counter = Random.Range(0, 10);
            if (counter >= 8)
            {
                GameObject t_attack = Instantiate(bossAttack, bossAttackAppear.position, Quaternion.identity);
                t_attack.transform.SetParent(this.transform);
            }
            Debug.Log(counter);
        }
    }
}
