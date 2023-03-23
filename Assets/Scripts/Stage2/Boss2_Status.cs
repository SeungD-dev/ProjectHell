using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss2_HPtime = 90;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            currentHp -= 1;
            Destroy(other.gameObject);
        }
    }
}
