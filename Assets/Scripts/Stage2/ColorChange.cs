using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject[] gameObjects;  
   
    public Color white = Color.white;
   
    public Color[] colors = { Color.red, new Color(246, 187, 67), Color.yellow, Color.green, Color.blue, new Color(139,0,255)  };
    
   
    private float time;  // time until the next color change
    private float colorTime;
    public Light[] spotLight;
    public List<int> usedColors;
    AttackRandomSpawn ars;
    public int random;
    

  

    void Start()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        usedColors = new List<int>();
        time = 15.0f;
        colorTime = 0.0f;

       
      
    }


    void Update()
    {
        if(ars.isAttackDestroyed == true)
        {
            
            StartCoroutine(SetColor());
        }
        else
        {
            colorTime += Time.deltaTime;
            if (colorTime > 2)
            {
                colorTime = 0.0f;
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Renderer>().material.color = white;
                    spotLight[i].color = white;
                }
            }
        }
      
        time -= Time.deltaTime;
        
       
       


    }
    IEnumerator SetColor()
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
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<Renderer>().material.color = white;
            spotLight[i].color = white;
        }

    }



}
