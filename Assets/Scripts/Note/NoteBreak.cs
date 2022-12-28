using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBreak : MonoBehaviour
{
    public GameObject player;
  
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Note_G"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Note_B"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Note_X"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(0, 0.2f, -2.8f);
            
           
        }
    }
}
