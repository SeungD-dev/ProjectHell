using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public List<GameObject> spawnPoint;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, spawnPoint.Count);
            Instantiate(key, spawnPoint[rand].transform.position, Quaternion.identity);
            spawnPoint.RemoveAt(rand);
        }
    }
}
