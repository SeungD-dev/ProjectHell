using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public int bossHp = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHp == 0)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossAttack"))
        {
            bossHp -= 1;
        }
    }
}
