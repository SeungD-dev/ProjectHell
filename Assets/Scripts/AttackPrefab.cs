using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrefab : MonoBehaviour
{

    Vector3 position;
    private float attackSpeed = 25;
   

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        position.z += attackSpeed * Time.deltaTime;
        transform.position = position;
    }
}
