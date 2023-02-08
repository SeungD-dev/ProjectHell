using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbAction : MonoBehaviour
{
    PlayerMove playerMove;
    TestBossAttack testBossAttack;
    public GameObject AbsorbButton;
    public GameObject absorb;
    public GameObject[] attackPrefabs;
    public GameObject attack_Player;
    public Transform playerPosition;
    public int attackNum;
    float countTime, absorbTime = 0.1f;
    public bool crtDo = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        testBossAttack = FindObjectOfType<TestBossAttack>();
        AbsorbButton = GameObject.Find("AbsorbButton");
        absorb = GameObject.Find("Absorb");
    }

    // Update is called once per frame
    void Update()
    {
        //attackNum = bossRandomAttack.attackShape;
        attackNum = testBossAttack.crtBossAttack;

        countTime += Time.deltaTime;
        this.gameObject.transform.position = playerPosition.position + new Vector3(-1, 0, 0);

        if (countTime >= absorbTime)
        {
            AbsorbColorTransparency();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        if (other.CompareTag("BossAttack"))
        {
            if (name == attackPrefabs[attackNum].name + "(Clone)")
            {
                Debug.Log("Á¤´ä");
                crtDo = true;
                Destroy(other.gameObject);
                Instantiate(attack_Player, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
            }
            else
            {
                playerMove.playerHp -= 1;
                crtDo = false;
                Destroy(other.gameObject);
            }
        }
    }

    public void goAbsorbButton()
    {
        countTime = 0;
        StartCoroutine("AttackCooldown");
        AbsorbUncolorTrasparency();
    }

    public void AbsorbColorTransparency()
    {
        GetComponent<MeshRenderer>().materials[0].color = new Color(0, 0, 0, 0f);
        //absorptionSprite.color = new Color(0, 100, 100, 0f);
        absorb.GetComponent<BoxCollider>().enabled = false;
    }

    public void AbsorbUncolorTrasparency()
    {
        GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0, 1f);
        //absorptionSprite.color = new Color(0, 0, 0, 1f);
        absorb.GetComponent<BoxCollider>().enabled = true;

    }
    IEnumerator AttackCooldown()
    {
        AbsorbButton.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        AbsorbButton.SetActive(true);
    }
}
