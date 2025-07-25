using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBreak_1 : MonoBehaviour
{
    public GameObject player;
    
    public float setTime = 0.5f;
    float time;
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X") ||
            other.CompareTag("Note_Fake") || other.CompareTag("BossAttack") || other.CompareTag("Note_AbsorbX") || other.CompareTag("SwordTrail") ||
            other.CompareTag("SwordTrail_Vertical") || other.CompareTag("Note_BB") || other.CompareTag("Note_BG") || other.CompareTag("Note_BR"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(0, 0.2f, -2.8f);
        }
    }
}
