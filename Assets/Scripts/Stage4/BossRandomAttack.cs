using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomAttack : MonoBehaviour
{
    BossRandomMoved bossRandomMoved;

    List<int> cubeList1 = new List<int>();
    List<int> cubeList2 = new List<int>();
    List<int> cubeList3 = new List<int>();

    public List<int> positionList1 = new List<int>();
    public List<int> positionList2 = new List<int>();
    public List<int> positionList3 = new List<int>();
    public List<int> positionList = new List<int>();
    public GameObject[] boss;
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
    public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        boss4 = true;
        bossRandomMoved = FindObjectOfType<BossRandomMoved>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (bossHp > 15 && bossHp <= 20)
        {
            boss4 = true;
        }
        else if (bossHp > 10 && bossHp <= 15)
        {
            boss4 = false;
            boss[0].SetActive(false);
            boss3 = true;
        }
        else if (bossHp > 5 && bossHp <= 10)
        {
            boss3 = false;
            boss[1].SetActive(false);
            boss2 = true;
        }
        else if (bossHp > 0 && bossHp <= 5)
        {
            boss2 = false;
            boss[2].SetActive(false);
            boss1 = true;
        }

        if (attackMode == true)
        {
            //bossRandomMoved.stop = true;
            attackShape = Random.Range(0, 4);
            attackPositioneRandom();
            CreateUnDuplicateRandom();

            if(time >= 1.5f)
            {
                if (boss4 == true)
                {
                    for (int i = 1; i < cubeList1.Count; i++)
                        Instantiate(attackPrefabs[cubeList1[i]], attackPoints_1[positionList1[i]].position + new Vector3(1, 1, 0), Quaternion.identity);
                    Instantiate(attackPrefabs[attackShape], attackPoints_1[positionList1[0]].position + new Vector3(1, 1, 0), Quaternion.identity);
                    cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                    positionList1.Clear(); positionList2.Clear(); positionList3.Clear();
                    attackMode = false;
                    time = 0;
                }
                else if (boss3 == true)
                {
                    for (int i = 1; i < cubeList2.Count; i++)
                        Instantiate(attackPrefabs[cubeList2[i]], attackPoints_2[positionList2[i]].position + new Vector3(1, 1, 0), Quaternion.identity);
                    Instantiate(attackPrefabs[attackShape], attackPoints_2[0].position + new Vector3(1, 1, 0), Quaternion.identity);
                    cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                    positionList1.Clear(); positionList2.Clear(); positionList3.Clear();
                    attackMode = false;
                    time = 0;
                }
                else if (boss2 == true)
                {
                    Instantiate(attackPrefabs[cubeList3[1]], attackPoints_3[positionList3[1]].position + new Vector3(1, 1, 0), Quaternion.identity);
                    Instantiate(attackPrefabs[attackShape], attackPoints_3[0].position + new Vector3(1, 1, 0), Quaternion.identity);
                    cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                    positionList1.Clear(); positionList2.Clear(); positionList3.Clear();
                    attackMode = false;
                    time = 0;
                }
                else if (boss1 == true)
                {
                    Instantiate(attackPrefabs[attackShape], attackPoints_4.position + new Vector3(1, 1, 0), Quaternion.identity);
                    attackMode = false;
                    time = 0;
                }
            }
        }
        else if (attackMode == false)
        {
            time = 0;
            //bossRandomMoved.stop = false;
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

    void attackPositioneRandom()
    {
        positionList1.Add(0);
        positionList2.Add(0);
        positionList3.Add(0);

        int currentNumber1 = Random.Range(0, 4);
        for (int i = 0; i < 3;)
        {
            if (positionList1.Contains(currentNumber1))
            {
                currentNumber1 = Random.Range(0, 4);
            }
            else
            {
                positionList1.Add(currentNumber1);
                i++;
            }
        }

        int currentNumber2 = Random.Range(0, 4);
        for (int i = 0; i < 2;)
        {
            if (positionList2.Contains(currentNumber2))
            {
                currentNumber2 = Random.Range(0, 4);
            }
            else
            {
                positionList2.Add(currentNumber2);
                i++;
            }
        }

        int currentNumber3 = Random.Range(0, 4);
        for (int i = 0; i < 1;)
        {
            if (positionList3.Contains(currentNumber3))
            {
                currentNumber3 = Random.Range(0, 4);
            }
            else
            {
                positionList3.Add(currentNumber3);
                i++;
            }
        }
    }
}
    
