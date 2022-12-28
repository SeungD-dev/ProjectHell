using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    
    public GameObject[] AttackPrefab;
    AttackEvent attackEvent;
    [SerializeField] Transform attackAppear = null;
    

    // Start is called before the first frame update
    void Start()
    {
        

        attackEvent = FindObjectOfType<AttackEvent>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        ShootAttack();
    }

    public void ShootAttack()
    {
        if(attackEvent.Attackmode == true && attackEvent.r == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[0], attackAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;

        }
        if (attackEvent.Attackmode == true && attackEvent.b == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[1], attackAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;

        }
        if (attackEvent.Attackmode == true && attackEvent.g == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[2], attackAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;

        }

    }
}
