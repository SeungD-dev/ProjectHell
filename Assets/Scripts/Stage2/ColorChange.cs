using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject[] gameObjects;  // array of GameObjects to change color
   
    public Color white = Color.white;
    public Color orange = new Color(246, 187, 67);
    private Color[] colors = { Color.red, new Color(246, 187, 67), Color.yellow, Color.green, Color.blue, new Color(139,0,255)  };
    
   
    private float time;  // time until the next color change
    private float colorTime;
    public Light[] spotLight;
    private List<int> usedColors;

    void Start()
    {
        usedColors = new List<int>();
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
            time = 3.0f;
        }
        if (colorTime >= 2.0f)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<Renderer>().material.color = white;
                spotLight[i].color = white;
            }
            colorTime = 0.0f;
        }
    }
    void SetColor()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            int random = Random.Range(0, colors.Length);
            while (usedColors.Contains(random))
            {
                random = Random.Range(0, colors.Length);
            }
            gameObjects[i].GetComponent<Renderer>().material.color = colors[random];
            spotLight[i].color = colors[random];
            usedColors.Add(random);
        }
        usedColors.Clear();
    }



    /* void SetColor()
     {
         for (int i = 0; i < gameObjects.Length; i++)
         {
             int random = Random.Range(0, colors.Length);
             gameObjects[i].GetComponent<Renderer>().material.color = colors[random];
             spotLight[i].color = colors[random];
         }
         colorTime = 0.0f;
     }*/
}
