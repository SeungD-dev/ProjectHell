using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossMove : MonoBehaviour
{
    float time;
    bool left1 = false;
    bool left2 = false;
    bool left3 = false;
    bool left4 = false;
    public bool oneAttack = true;
    public bool stop = false;
    Vector3[] position = new Vector3[4];
    public Transform[] boss;
    Vector3[] randomPosition = { new Vector3(-13, 1, -6), new Vector3(-13, 1, -2), new Vector3(-13, 1, 2), new Vector3(-13, 1, 6) };
    TestBossAttack testBossAttack;

    void Start()
    {
        Debug.Log(boss[0].transform.position);
        for (int i = 0; i < 4; i++)
        {
            position[i] = boss[i].transform.position;
        }
        testBossAttack = FindObjectOfType<TestBossAttack>();
    }
    // boss[i].transform.position = Vector3.MoveTowards(boss[i].transform.position, randomPosition[3], 0.02f);
    // Update is called once per frame
    void Update()
    {
        if (time >= 4)
            stop = true;
        if (!stop)
        {
            if (left1 == false)
            {
                boss[0].transform.position = Vector3.MoveTowards(boss[0].transform.position, randomPosition[3], 0.02f);
                if (boss[0].transform.position == randomPosition[3])
                    left1 = true;
            }
            if (left1 == true)
            {
                boss[0].transform.position = Vector3.MoveTowards(boss[0].transform.position, randomPosition[0], 0.02f);
                if (boss[0].transform.position == randomPosition[0])
                    left1 = false;
            }

            if (left2 == false)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[3], 0.02f);
                if (boss[1].transform.position == randomPosition[3])
                    left2 = true;
            }
            if (left2 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[0], 0.02f);
                if (boss[1].transform.position == randomPosition[0])
                    left2 = false;
            }

            if (left3 == false)
            {
                boss[2].transform.position = Vector3.MoveTowards(boss[2].transform.position, randomPosition[3], 0.02f);
                if (boss[2].transform.position == randomPosition[3])
                    left3 = true;
            }
            if (left3 == true)
            {
                boss[2].transform.position = Vector3.MoveTowards(boss[2].transform.position, randomPosition[0], 0.02f);
                if (boss[2].transform.position == randomPosition[0])
                    left3 = false;
            }

            if (left4 == false)
            {
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, randomPosition[3], 0.02f);
                if (boss[3].transform.position == randomPosition[3])
                    left4 = true;
            }
            if (left4 == true)
            {
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, randomPosition[0], 0.02f);
                if (boss[3].transform.position == randomPosition[0])
                    left4 = false;
            }
            time += Time.deltaTime;
            oneAttack = true;
        }
        else if (stop == true)
        {
            if (testBossAttack.boss4 == true)
            {
                boss[0].transform.position = Vector3.MoveTowards(boss[0].transform.position, randomPosition[testBossAttack.attackPlace[0]], 0.02f);
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[testBossAttack.attackPlace[1]], 0.02f);
                boss[2].transform.position = Vector3.MoveTowards(boss[2].transform.position, randomPosition[testBossAttack.attackPlace[2]], 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, randomPosition[testBossAttack.attackPlace[3]], 0.02f);
                if (boss[0].transform.position == randomPosition[testBossAttack.attackPlace[0]] && boss[1].transform.position == randomPosition[testBossAttack.attackPlace[1]] &&
                    boss[2].transform.position == randomPosition[testBossAttack.attackPlace[2]] && boss[3].transform.position == randomPosition[testBossAttack.attackPlace[3]] && oneAttack == true)
                {
                    testBossAttack.goAttack = true;
                    oneAttack = false;
                }
                time = 0;
            }
            if (testBossAttack.boss3 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[testBossAttack.attackPlace[1]], 0.02f);
                boss[2].transform.position = Vector3.MoveTowards(boss[2].transform.position, randomPosition[testBossAttack.attackPlace[0]], 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, randomPosition[testBossAttack.attackPlace[2]], 0.02f);
                if (boss[1].transform.position == randomPosition[testBossAttack.attackPlace[1]] &&
                    boss[2].transform.position == randomPosition[testBossAttack.attackPlace[0]] && boss[3].transform.position == randomPosition[testBossAttack.attackPlace[2]] && oneAttack == true)
                {
                    testBossAttack.goAttack = true;
                    oneAttack = false;
                }
                time = 0;
            }
            if (testBossAttack.boss2 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[testBossAttack.attackPlace[1]], 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, randomPosition[testBossAttack.attackPlace[0]], 0.02f);
                if (boss[1].transform.position == randomPosition[testBossAttack.attackPlace[1]] && boss[3].transform.position == randomPosition[testBossAttack.attackPlace[0]] && oneAttack == true)
                {
                    testBossAttack.goAttack = true;
                    oneAttack = false;
                }
                time = 0;
            }
            if (testBossAttack.boss1 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, randomPosition[testBossAttack.attackPlace[0]], 0.02f);
                if (boss[1].transform.position == randomPosition[testBossAttack.attackPlace[0]] && oneAttack == true)
                {
                    testBossAttack.goAttack = true;
                    oneAttack = false;
                }
                time = 0;
            }
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¥Í¿Ω");
        if (other.CompareTag("BossAttack"))
        {
            testBossAttack.bossHp -= 1;
            stop = false;
            testBossAttack.attackMode = true;
            Destroy(other.gameObject);
        }
    }
}
