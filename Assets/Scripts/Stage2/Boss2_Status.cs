using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss2_HPtime = 90;
    public GameObject Line;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    // Update is called once per frame
    {
        boss2_HPtime -= Time.deltaTime;
        Debug.Log(scene.name);
        if (currentHp <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Debug.Log(scene.name);
            Invoke("LoadScene", 1f);
        }
        if (boss2_HPtime <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Invoke("LoadScene", 1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Stage1_Clear");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            currentHp -= 1;
            Destroy(other.gameObject);
        }
    }
}
