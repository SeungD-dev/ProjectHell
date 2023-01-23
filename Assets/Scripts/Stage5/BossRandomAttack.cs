using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomAttack : MonoBehaviour
{
    List<int> cubeList = new List<int>();
    public GameObject[] attackPrefabs;
    public Transform[] attackPoints;
    public bool attackMode = true;
    public int attackNum;
    public int pointNum;

    // Start is called before the first frame update
    void Start()
    {
        CreateUnDuplicateRandom(0, 4);
        attackNum = Random.Range(0, attackPrefabs.Length);
        pointNum = Random.Range(0, attackPoints.Length);
        for (int i = 0; i < cubeList.Count; i++)
        {
            Debug.Log(cubeList[i]);
            //Instantiate(cube, new Vector3(i, 0, cubeList[i]), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackMode == true)
        {
            for (int i = 0; i < cubeList.Count; i++)
            {
                Instantiate(attackPrefabs[cubeList[i]], attackPoints[i].position, Quaternion.identity);
            }
            attackMode = false;
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
