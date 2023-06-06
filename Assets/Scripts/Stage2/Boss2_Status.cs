using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss2_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss2_HPtime = 120;
    public GameObject Line;
    public GameObject hitParticle;
    public bool isHit , isHit_ph2, timeStop = false;
    public AudioClip[] ad;
    AudioSource audio;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        scene = SceneManager.GetActiveScene();
        audio = this.GetComponent<AudioSource>();
        hitParticle.SetActive(false);
    }

    void Update()
    // Update is called once per frame
    {
        if (!timeStop)
        {
            boss2_HPtime -= Time.deltaTime;
        }
       
        if (currentHp <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Debug.Log(scene.name);
            Invoke("LoadScene", 4f);
        }
        if (boss2_HPtime <= 0)
        {
            Line.SetActive(false);
            Destroy(GameObject.FindWithTag("SwordTrail"));
            Destroy(GameObject.FindWithTag("SwordTrail_Vertical"));
            GameResultButton.clear = scene.name;
            Invoke("LoadScene", 4f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Stage1_Clear");
    }

    void BossHitParticle()
    {
        hitParticle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            currentHp -= 1;
            hitParticle.SetActive(true);
            Invoke("BossHitParticle", 1f);
            Destroy(other.gameObject);
            isHit = true;
            audio.clip = ad[Random.Range(0, 2)];
            audio.Play();
        }
    }
}
