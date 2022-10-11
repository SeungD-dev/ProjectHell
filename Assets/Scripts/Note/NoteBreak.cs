using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBreak : MonoBehaviour
{
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
    }
}
