using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomAttack : MonoBehaviour
{
    List<int> cubeList1 = new List<int>();
    List<int> cubeList2 = new List<int>();
    List<int> cubeList3 = new List<int>();
    public List<int> positionList = new List<int>();
    public GameObject[] attackPrefabs;
    public Transform[] attackPoints_1;
    public Transform[] attackPoints_2;
    public Transform[] attackPoints_3;
    public Transform attackPoints_4;
    public bool attackMode = true;
    public bool boss4, boss3, boss2, boss1 = false;
    public int pointNum;
    public int attackShape;
    public int bossHp = 20;
    float time = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        boss4 = true;
        positionRandom();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (attackMode == true)
        {
            if(time >= 3)
            {
                attackShape = Random.Range(0, 4);
                CreateUnDuplicateRandom();
            }
            if (boss4 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_1.Length);
                for (int i = 1; i < cubeList1.Count; i++)
                    Instantiate(attackPrefabs[cubeList1[i]], attackPoints_1[i].position + new Vector3(1, 1, 0), Quaternion.identity);
                Instantiate(attackPrefabs[attackShape], attackPoints_1[0].position + new Vector3(1, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                attackMode = false;
                time = 0;
            } else if(boss3 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_2.Length);
                for (int i = 1; i < cubeList2.Count; i++)
                    Instantiate(attackPrefabs[cubeList2[i]], attackPoints_2[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(attackPrefabs[attackShape], attackPoints_2[0].position + new Vector3(0, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                attackMode = false;
            }
            else if (boss2 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_3.Length);
                Instantiate(attackPrefabs[cubeList3[1]], attackPoints_3[1].position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(attackPrefabs[attackShape], attackPoints_3[0].position + new Vector3(0, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                attackMode = false;
            }
            else if (boss1 == true)
            {
                Instantiate(attackPrefabs[attackShape], attackPoints_4.position + new Vector3(0, 1, 0), Quaternion.identity);
                attackMode = false;
            }
        }
    }

    void CreateUnDuplicateRandom()
    {
        cubeList1.Add(attackShape);
        cubeList2.Add(attackShape);
        cubeList3.Add(attackShape);

        int currentNumber1 = Random.Range(0, 4);
        for (int i = 0; i < 3;)
        {
            if (cubeList1.Contains(currentNumber1) && cubeList1.Contains(attackShape))
            {
                currentNumber1 = Random.Range(0, 4);
            }
            else
            {
                cubeList1.Add(currentNumber1);
                i++;
            }
        }

        int currentNumber2 = Random.Range(0, 4);
        for (int i = 0; i < 2;)
        {
            if (cubeList2.Contains(currentNumber2))
            {
                currentNumber2 = Random.Range(0, 4);
            }
            else
            {
                cubeList2.Add(currentNumber2);
                i++;
            }
        }

        int currentNumber3 = Random.Range(0, 4);
        for (int i = 0; i < 1;)
        {
            if (cubeList3.Contains(currentNumber3))
            {
                currentNumber3 = Random.Range(0, 4);
            }
            else
            {
                cubeList3.Add(currentNumber3);
                i++;
            }
        }
    }

    void positionRandom()
    {
        int currentNumber = Random.Range(0, 4);
        for (int i = 0; i < 4;)
        {
            if (positionList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, 4);
            }
            else
            {
                positionList.Add(currentNumber);
                i++;
            }
        }
    }
}
    
