using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossAttack : MonoBehaviour
{
    PlayerMove playerMove;
    AbsorbAction absorbAction;
    public bool attackMode = true;
    public List<int> attackList = new List<int>();
    public List<int> attackPlace = new List<int>();
    public GameObject[] boss;
    Vector3[] randomPosition = { new Vector3(-12, 1, -6), new Vector3(-12, 1, -2), new Vector3(-12, 1, 2), new Vector3(-12, 1, 6) };
    public GameObject[] attackPrefabs;
    public bool boss4, boss3, boss2, boss1 = false;
    public bool goAttack = false;
    public int bossHp = 20;
    public int crtBossAttack;
    public int crtBossPlace;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        absorbAction = FindObjectOfType<AbsorbAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHp > 15)
        {
            boss4 = true;
        }
        else if (bossHp <= 15 && bossHp > 10)
        {
            boss4= false;
            boss[0].SetActive(false);
            boss3 = true;
        }
        else if (bossHp <= 10 && bossHp > 5)
        {
            boss3 = false;
            boss[2].SetActive(false);
            boss2 = true;
        }
        else if (bossHp <= 5)
        {
            boss2 = false;
            boss[3].SetActive(false);
            boss1 = true;
        }
        else if (bossHp == 0)
        {
            boss[1].SetActive(false);
            boss1 = false;
        }

        if(attackMode == true) // 보스 공격과 위치 바꾸기
        {
            attackList.Clear();
            attackPlace.Clear();

            crtBossAttack = Random.Range(0, 4); // 보스공격 정답
            attackList.Add(crtBossAttack);

            crtBossPlace = Random.Range(0, 4); // 정답 보스 자리
            attackPlace.Add(crtBossPlace);

            RandomAttackPrefab(); // 보스 페이크 공격 중복없는 랜덤값
            RandomAttackPlace(); // 나머지 보스 위치 중복없는 랜덤값
            attackMode = false;
        }

        if (boss4 == true && goAttack == true)
        {
            Instantiate(attackPrefabs[attackList[0]], randomPosition[attackPlace[0]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[1]], randomPosition[attackPlace[1]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[2]], randomPosition[attackPlace[2]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[3]], randomPosition[attackPlace[3]], Quaternion.identity);
            playerMove.oneDamage = false;
            absorbAction.crtDo = false;
            goAttack = false;
        }
        else if (boss3 == true && goAttack == true)
        {
            Instantiate(attackPrefabs[attackList[0]], randomPosition[attackPlace[0]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[1]], randomPosition[attackPlace[1]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[2]], randomPosition[attackPlace[2]], Quaternion.identity);
            playerMove.oneDamage = false;
            absorbAction.crtDo = false;
            goAttack = false;
        }
        else if (boss2 == true && goAttack == true)
        {
            Instantiate(attackPrefabs[attackList[0]], randomPosition[attackPlace[0]], Quaternion.identity);
            Instantiate(attackPrefabs[attackList[1]], randomPosition[attackPlace[1]], Quaternion.identity);
            playerMove.oneDamage = false;
            absorbAction.crtDo = false;
            goAttack = false;
        }
        else if (boss1 == true && goAttack == true)
        {
            Instantiate(attackPrefabs[attackList[0]], randomPosition[attackPlace[0]], Quaternion.identity);
            playerMove.oneDamage = false;
            absorbAction.crtDo = false;
            goAttack = false;
        }
    }

    void RandomAttackPrefab()
    {
        int currentNumber1 = Random.Range(0, 4);
        for (int i = 0; i < 3;)
        {
            if (attackList.Contains(currentNumber1))
            {
                currentNumber1 = Random.Range(0, 4);
            }
            else
            {
                attackList.Add(currentNumber1);
                i++;
            }
        }
    }

    void RandomAttackPlace()
    {
        int currentNumber1 = Random.Range(0, 4);
        for (int i = 0; i < 3;)
        {
            if (attackPlace.Contains(currentNumber1))
            {
                currentNumber1 = Random.Range(0, 4);
            }
            else
            {
                attackPlace.Add(currentNumber1);
                i++;
            }
        }
    }
}
