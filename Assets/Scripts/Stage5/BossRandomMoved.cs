using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomMoved : MonoBehaviour
{
    float time;
    bool left1 = false;
    bool left2 = false;
    bool left3 = false;
    bool left4 = false;
    public bool stop = false;
    Vector3[] position = new Vector3[4];
    public Transform[] boss;
    Vector3[] randomPosition = { new Vector3(-13, 1, -6), new Vector3(-13, 1, -2), new Vector3(-13, 1, 2), new Vector3(-13, 1, 6) };
    BossRandomAttack bossRandomAttack;

    void Start()
    {
        Debug.Log(boss[0].transform.position);
        for(int i = 0; i < 4; i++)
        {
            position[i] = boss[i].transform.position;
        }
        bossRandomAttack = FindObjectOfType<BossRandomAttack>();
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
        }
        else if (stop == true)
        {
            if (bossRandomAttack.boss4 == true)
            {
                boss[0].transform.position = Vector3.MoveTowards(boss[0].transform.position, bossRandomAttack.attackPoints_1[0].position + new Vector3(0, 1, 0), 0.02f);
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, bossRandomAttack.attackPoints_1[bossRandomAttack.positionList1[1]].position + new Vector3(0, 1, 0), 0.02f);
                boss[2].transform.position = Vector3.MoveTowards(boss[2].transform.position, bossRandomAttack.attackPoints_1[bossRandomAttack.positionList1[2]].position + new Vector3(0, 1, 0), 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, bossRandomAttack.attackPoints_1[bossRandomAttack.positionList1[3]].position + new Vector3(0, 1, 0), 0.02f);
            }
            if (bossRandomAttack.boss3 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, bossRandomAttack.attackPoints_2[bossRandomAttack.positionList2[1]].position + new Vector3(0, 1, 0), 0.02f);
                boss[2].transform.position = Vector3.MoveTowards(boss[0].transform.position, bossRandomAttack.attackPoints_2[0].position + new Vector3(0, 1, 0), 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[3].transform.position, bossRandomAttack.attackPoints_2[bossRandomAttack.positionList2[2]].position + new Vector3(0, 1, 0), 0.02f);
            }
            if (bossRandomAttack.boss2 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[1].transform.position, bossRandomAttack.attackPoints_3[bossRandomAttack.positionList3[1]].position + new Vector3(0, 1, 0), 0.02f);
                boss[3].transform.position = Vector3.MoveTowards(boss[0].transform.position, bossRandomAttack.attackPoints_3[0].position + new Vector3(0, 1, 0), 0.02f);
            }
            if (bossRandomAttack.boss1 == true)
            {
                boss[1].transform.position = Vector3.MoveTowards(boss[0].transform.position, bossRandomAttack.attackPoints_4.position + new Vector3(0, 1, 0), 0.02f);
            }
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¥Í¿Ω");
        if (other.CompareTag("BossAttack"))
        {
            bossRandomAttack.bossHp -= 1;
            Destroy(other.gameObject);
        }
    }
}
