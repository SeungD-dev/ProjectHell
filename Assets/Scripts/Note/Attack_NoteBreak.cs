using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_NoteBreak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B")
            || other.CompareTag("Note_X"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
