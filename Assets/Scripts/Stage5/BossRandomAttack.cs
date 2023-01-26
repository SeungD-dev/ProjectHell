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
    public bool goAttack = true;
    public bool boss4, boss3, boss2, boss1 = false;
    public int attackNum;
    public int pointNum;
    public int attackShape;
    
    // Start is called before the first frame update
    void Start()
    {
        boss4 = true;
        CreateUnDuplicateRandom();
        positionRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (goAttack == true)
        {
            attackShape = Random.Range(0, 4);
            goAttack = false;
        }

        if (attackMode == true)
        { 
            if (boss4 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_1.Length);
                for (int i = 0; i < cubeList1.Count; i++)
                    Instantiate(attackPrefabs[cubeList1[i]], attackPoints_1[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                CreateUnDuplicateRandom();
                attackMode = false;
            } else if(boss3 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_2.Length);
                for (int i = 0; i < cubeList2.Count; i++)
                    Instantiate(attackPrefabs[cubeList2[i]], attackPoints_2[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                CreateUnDuplicateRandom();
                attackMode = false;
            }
            else if (boss2 == true)
            {
                //attackNum = Random.Range(0, attackPrefabs.Length);
                pointNum = Random.Range(0, attackPoints_3.Length);
                for (int i = 0; i < cubeList3.Count; i++)
                    Instantiate(attackPrefabs[cubeList3[i]], attackPoints_3[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                cubeList1.Clear(); cubeList2.Clear(); cubeList3.Clear();
                CreateUnDuplicateRandom();
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
        int currentNumber1 = Random.Range(0, 4);
        for (int i = 0; i < 4;)
        {
            if (cubeList1.Contains(currentNumber1))
            {
                currentNumber1 = Random.Range(0, 4);
            }
            else
            {
                cubeList1.Add(currentNumber1);
                i++;
            }
        }

        int currentNumber2 = Random.Range(0, 3);
        for (int i = 0; i < 3;)
        {
            if (cubeList2.Contains(currentNumber2))
            {
                currentNumber2 = Random.Range(0, 3);
            }
            else
            {
                cubeList2.Add(currentNumber2);
                i++;
            }
        }

        int currentNumber3 = Random.Range(0, 2);
        for (int i = 0; i < 2;)
        {
            if (cubeList3.Contains(currentNumber3))
            {
                currentNumber3 = Random.Range(0, 2);
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
    
