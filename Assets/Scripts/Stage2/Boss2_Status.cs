using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
    }
}
