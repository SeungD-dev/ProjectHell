using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomAttack : MonoBehaviour
{
    List<int> cubeList = new List<int>();
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
        CreateUnDuplicateRandom(0, 4);
        attackNum = Random.Range(0, attackPrefabs.Length);
        pointNum = Random.Range(0, attackPoints_1.Length);
        for (int i = 0; i < cubeList.Count; i++)
        {
            Debug.Log(cubeList[i]);
            //Instantiate(cube, new Vector3(i, 0, cubeList[i]), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goAttack == true)
        {
            attackShape = Random.Range(0, 4);
            goAttack = false;
        }
        if (boss4 == true)
        {
            if (attackMode == true)
            {
                for (int i = 0; i < cubeList.Count; i++)
                    Instantiate(attackPrefabs[cubeList[i]], attackPoints_1[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                attackMode = false;
            }
        }
        else if(boss3 == true)
        {
            if (attackMode == true)
            {
                for (int i = 0; i < cubeList.Count; i++)
                    Instantiate(attackPrefabs[cubeList[i]], attackPoints_2[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                attackMode = false;
            }
        }
        else if(boss2 == true)
        {
            if (attackMode == true)
            {
                for (int i = 0; i < cubeList.Count; i++)
                    Instantiate(attackPrefabs[cubeList[i]], attackPoints_3[i].position + new Vector3(0, 1, 0), Quaternion.identity);
                attackMode = false;
            }
        }
        else if(boss2 == true)
        {
            if (attackMode == true)
            {
                for (int i = 0; i < cubeList.Count; i++)
                    Instantiate(attackPrefabs[cubeList[i]], attackPoints_4.position + new Vector3(0, 1, 0), Quaternion.identity);
                attackMode = false;
            }
        }
    }

    void CreateUnDuplicateRandom(int min, int max)
    {
        int currentNumber = Random.Range(min, max);

        for (int i = 0; i < max;)
        {
            if (cubeList.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
            }
            else
            {
                cubeList.Add(currentNumber);
                i++;
            }
        }
    }
}
