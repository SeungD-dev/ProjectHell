using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject[] gameObjects;  
   
    public Color white = Color.white;
    BossAttackMove bossAttackMove;
    Renderer rend;




    public Light[] spotLight;
   
    AttackRandomSpawn ars;
   
    List<Vector3> coordinates = new List<Vector3>()
    {
        new Vector3(10,0,-4),
        new Vector3(10,0,4),
        new Vector3(-8,0,0)
    };
   
 



    GameObject Lf, SL,Lf1,SL1,Lf2,SL2 ,Spotlight1,Spotlight2,Spotlight3,LightField1,LightField2,LightField3;
    bool rotateOn;

    void Start()
    {
        ars = FindObjectOfType<AttackRandomSpawn>();
        rend = GetComponent<Renderer>();
        bossAttackMove = FindObjectOfType<BossAttackMove>();

        Lf = GameObject.Find("LF");
        SL = GameObject.Find("SL");
        Lf1 = GameObject.Find("LF1");
        SL1 = GameObject.Find("SL1");
        Lf2 = GameObject.Find("LF2");
        SL2 = GameObject.Find("SL2");
        Spotlight1 = GameObject.Find("Spot Light1");
        Spotlight2 = GameObject.Find("Spot Light2");
        Spotlight3 = GameObject.Find("Spot Light3");
        LightField1 = GameObject.Find("LightField1");
        LightField2 = GameObject.Find("LightField2");
        LightField3 = GameObject.Find("LightField3");
        Lf.GetComponent<Renderer>().material.color = Color.black;
        SL.GetComponent<Light>().color = Color.black;
        Lf1.GetComponent<Renderer>().material.color = Color.black;
        SL1.GetComponent<Light>().color = Color.black;
        Lf2.GetComponent<Renderer>().material.color = Color.black;
        SL2.GetComponent<Light>().color = Color.black;

        ColorManager.colors = new Color[]  { Color.red, new Color32(255, 141, 0,255), Color.yellow, Color.green, Color.blue, new Color32(139, 0, 255,255) };
       
        Lf.SetActive(false);
        SL.SetActive(false);
        Lf1.SetActive(false);
        SL1.SetActive(false);
        Lf2.SetActive(false);
        SL2.SetActive(false);




    }


    void Update()
    {
        if(ars.isAttackDestroyed == true)
        {
            
            StartCoroutine(SetColor());
            LightFieldRotate();



        }
      
      



    }

    void LightFieldRotate()
    {

        List<Vector3> usedCoordinates = new List<Vector3>();

        for (int i = 0; i < 3; i++)
        {
            Vector3 randomCoordinate;
            do
            {
                randomCoordinate = coordinates[Random.Range(0, coordinates.Count)];
            } while (usedCoordinates.Contains(randomCoordinate));
            usedCoordinates.Add(randomCoordinate);

            switch (i)
            {
                case 0:
                    LightField1.transform.position = randomCoordinate;
                    Spotlight1.transform.position = new Vector3(-1.4f, 23f,-1.9f) + randomCoordinate;
                    break;
                case 1:
                    LightField2.transform.position = randomCoordinate;
                    Spotlight2.transform.position = new Vector3(-1.4f, 23f, -1.9f) + randomCoordinate; 
                    break;
                case 2:
                    LightField3.transform.position = randomCoordinate;
                    Spotlight3.transform.position = new Vector3(-1.4f, 23f, -1.9f) + randomCoordinate;
                    break;
            }
        }
        usedCoordinates.Clear();




    }


    public IEnumerator SetColor()
    {
        Spotlight1.SetActive(true);
        Spotlight2.SetActive(true);
        Spotlight3.SetActive(true);
        Lf.SetActive(false);
        SL.SetActive(false);
        Lf1.SetActive(false);
        SL1.SetActive(false);
        Lf2.SetActive(false);
        SL2.SetActive(false);


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
            
        }
       

        //Debug.Log("SetColor" + ColorManager.randomColorIndex);
        
        yield return new WaitForSeconds(2f);
        Lf.SetActive(true);
        SL.SetActive(true);
        Lf1.SetActive(true);
        SL1.SetActive(true);
        Lf2.SetActive(true);
        SL2.SetActive(true);
        Spotlight1.SetActive(false);
        Spotlight2.SetActive(false);
        Spotlight3.SetActive(false);


        /*for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<Renderer>().material.color = white;
            spotLight[i].color = white;
        }*/
        ColorManager.usedColors.Clear();

    }

   



}
