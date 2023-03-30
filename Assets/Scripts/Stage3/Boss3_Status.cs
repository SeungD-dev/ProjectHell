using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss3_HPtime = 90;

    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    // Update is called once per frame
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            currentHp -= 1;
            Destroy(other.gameObject);
            isHit = true;
        }
    }
}
