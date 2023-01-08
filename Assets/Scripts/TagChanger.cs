using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    public Material[] mat = new Material[3];

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R"))
        {
            other.gameObject.tag = "Note_B";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[2];
        }
        if (other.CompareTag("Note_G"))
        {
            other.gameObject.tag = "Note_R";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[0];
        }
        if (other.CompareTag("Note_B"))
        {
            other.gameObject.tag = "Note_G";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[1];
        }
    }
}
