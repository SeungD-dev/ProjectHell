using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttack : MonoBehaviour
{
    AbsorbAction absorbAction;
    PlayerMove playerMove;
    public GameObject bossFailAttack;
    // Start is called before the first frame update
    void Start()
    {
        absorbAction = FindObjectOfType<AbsorbAction>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("BossAttack") && absorbAction.crtDo == false)
        {
            Instantiate(bossFailAttack, coll.transform.position, Quaternion.identity);

        }
        Destroy(coll.gameObject);
    }
}