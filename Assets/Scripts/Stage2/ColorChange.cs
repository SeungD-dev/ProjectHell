using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject[] gameObjects;  
   
    public Color white = Color.white;
    Renderer rend;





    public Light[] spotLight;
   
    AttackRandomSpawn ars;
    public int result;


    GameObject Lf, SL;

    void Start()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        rend = GetComponent<Renderer>();

        Lf = GameObject.Find("LF");
        SL = GameObject.Find("SL");
        Lf.GetComponent<Renderer>().material.color = Color.black;
        SL.GetComponent<Light>().color = Color.black;

        ColorManager.colors = new Color[]  { Color.red, new Color32(255, 141, 0,255), Color.yellow, Color.green, Color.blue, new Color32(139, 0, 255,255) };
        /*ColorManager.colors = new Color[6];
        ColorManager.colors[0] = Color.red;
        ColorManager.colors[1] = new Color32(255, 141, 0, 255);
        ColorManager.colors[2] = Color.yellow;
        ColorManager.colors[3] = Color.green;
        ColorManager.colors[4] = Color.blue;
        ColorManager.colors[5] = new Color32(139,0,255,255);*/
        Lf.SetActive(false);
        SL.SetActive(false);
       



    }


    void Update()
    {
        if(ars.isAttackDestroyed == true)
        {
            
            StartCoroutine(SetColor());
        }
        /*else
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
        }*/


       
       


    }
    public IEnumerator SetColor()
    {
        Lf.SetActive(false);
        SL.SetActive(false);
        for (int i = 0; i < gameObjects.Length; i++)
        {
           ColorManager.randomColorIndex = Random.Range(0, ColorManager.colors.Length);
            
            while (ColorManager.usedColors.Contains(ColorManager.colors[ColorManager.randomColorIndex])) 
            {
                ColorManager.randomColorIndex = Random.Range(0, ColorManager.colors.Length);
            }
          
            gameObjects[i].GetComponent<Renderer>().material.color = ColorManager.colors[ColorManager.randomColorIndex];
            
            spotLight[i].color = ColorManager.colors[ColorManager.randomColorIndex];
            
            ColorManager.usedColors.Add(ColorManager.colors[ColorManager.randomColorIndex]);
            ColorManager.changedColors.Add(ColorManager.colors[ColorManager.randomColorIndex]);
        }
        result = ColorManager.randomColorIndex;

        Debug.Log("SetColor" + ColorManager.randomColorIndex);
        
        yield return new WaitForSeconds(2f);
        Lf.SetActive(true);
        SL.SetActive(true);

        /*for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<Renderer>().material.color = white;
            spotLight[i].color = white;
        }*/
        ColorManager.usedColors.Clear();

    }

   



}
