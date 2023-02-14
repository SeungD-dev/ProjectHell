using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack_NoteBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X") ||
            other.CompareTag("Note_Fake") || other.CompareTag("BossAttack") || other.CompareTag("Note_AbsorbX") ||
            other.CompareTag("Note_BB") || other.CompareTag("Note_BG") || other.CompareTag("Note_BR"))
        {
            Destroy(other.gameObject);
        }
    }
}
