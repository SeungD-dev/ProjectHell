using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagChanger : MonoBehaviour
{
    public Sprite[] stage2_sprites = new Sprite[3];
    public Sprite[] stage3_sprites = new Sprite[6];
    LineActive_3 lineActive;

    private void Start()
    {
        lineActive = FindObjectOfType<LineActive_3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_CR"))
        {
            other.gameObject.tag = "Note_B";
            //other.gameObject.GetComponent<MeshRenderer>().material = mat[2];
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage2_sprites[2];
        }
        if (other.CompareTag("Note_CG"))
        {
            other.gameObject.tag = "Note_R";
            //other.gameObject.GetComponent<MeshRenderer>().material = mat[0];
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage2_sprites[0];
        }
        if (other.CompareTag("Note_CB"))
        {
            Debug.Log("¿€µø");
            other.gameObject.tag = "Note_G";
            //other.gameObject.GetComponent<MeshRenderer>().material = mat[1];
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage2_sprites[1];
        }
        if (SceneManager.GetActiveScene().name == "Stage_3")
        {
            if (lineActive.fade)
            {
                if (other.CompareTag("Note_R"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[0];
                }
                if (other.CompareTag("Note_G"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[1];
                }
                if (other.CompareTag("Note_B"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[2];
                }
            }
            if (!lineActive.fade)
            {
                if (other.CompareTag("Note_R"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[3];
                }
                if (other.CompareTag("Note_G"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[4];
                }
                if (other.CompareTag("Note_B"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[5];
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Stage_3")
        {
            if (lineActive.fade)
            {
                if (other.CompareTag("Note_R"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[0];
                }
                if (other.CompareTag("Note_G"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[1];
                }
                if (other.CompareTag("Note_B"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[2];
                }
            }
            if (!lineActive.fade)
            {
                if (other.CompareTag("Note_R"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[3];
                }
                if (other.CompareTag("Note_G"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[4];
                }
                if (other.CompareTag("Note_B"))
                {
                    other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stage3_sprites[5];
                }
            }
        }
    }
}
