using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float time;

    GameObject Tile2, Tile4, Fog;

    // Start is called before the first frame update
    void Start()
    {
        Tile2 = GameObject.Find("Tile2");
        Tile4 = GameObject.Find("Tile4");
        Fog = GameObject.Find("Fog");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage_1")
        {
            time += Time.deltaTime;
            if(time >= 100)
            {
                Tile2.SetActive(false);
                Tile4.SetActive(false);
            }
            if(time >= 5)
            {
                Fog.transform.position = new Vector3(0, 1.22f, 1.99f);
            }
        }
    }
}
