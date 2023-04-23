using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss2_HPtime = 120;
    public GameObject Line;
    public bool isHit , isHit_ph2;
    public AudioClip[] ad;
    AudioSource audio;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        scene = SceneManager.GetActiveScene();
        audio = this.GetComponent<AudioSource>();
    }

    void Update()
    // Update is called once per frame
    {
        boss2_HPtime -= Time.deltaTime;
        if (currentHp <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Debug.Log(scene.name);
            Invoke("LoadScene", 2f);
        }
        if (boss2_HPtime <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Invoke("LoadScene", 2f);
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
            isHit = true;
            audio.clip = ad[Random.Range(0, 2)];
            audio.Play();
        }
    }
}
