using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    CsRayCast rayCast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rayCast = GetComponent<CsRayCast>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "Key")
            rayCast.count++;
    }
}
