using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject[] gameObjects;  // array of GameObjects to change color
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color white = Color.white;
    private float time;  // time until the next color change
    private float colorTime;

    void Start()
    {
        time = 5.0f;
        colorTime = 0.0f;
        SetColor();
    }

    void Update()
    {
        time -= Time.deltaTime;
        colorTime += Time.deltaTime;
        if (time <= 0)
        {
            SetColor();
            time = 5.0f;
        }
        if (colorTime >= 2.0f)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<Renderer>().material.color = white;
            }
            colorTime = 0.0f;
        }
    }

    void SetColor()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                gameObjects[i].GetComponent<Renderer>().material.color = red;
            }
            else if (random == 1)
            {
                gameObjects[i].GetComponent<Renderer>().material.color = blue;
            }
            else if (random == 2)
            {
                gameObjects[i].GetComponent<Renderer>().material.color = green;
            }
        }
        colorTime = 0.0f;
    }
}
