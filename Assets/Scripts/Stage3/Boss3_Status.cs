using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3_Status : MonoBehaviour
{
    public int maxHp = 15;
    public int currentHp;
    public float boss3_HPtime = 90;

    public bool isHit = false, isHit_AtkTime1 = false, timeStop = true;
    public GameObject Line;
    public GameObject hitParticle;
    Scene scene;
    AudioSource audio;

    Reaper_Anim ra;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        scene = SceneManager.GetActiveScene();
        ra = FindObjectOfType<Reaper_Anim>();
        audio = this.GetComponent<AudioSource>();
        hitParticle.SetActive(false);
    }

    void Update()
    // Update is called once per frame
    {
        if (!timeStop)
        {
            boss3_HPtime -= Time.deltaTime;
        }        

        if (currentHp <= 0)
        {
            Line.SetActive(false);
            GameResultButton.clear = scene.name;
            Debug.Log(scene.name);
            Invoke("LoadScene", 1f);
        }
        if (boss3_HPtime <= 0)
        {
            Line.SetActive(false);
            GameResultButton.clear = scene.name;
            Invoke("LoadScene", 1f);
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
            Destroy(other.gameObject);
            hitParticle.SetActive(true);
            Invoke("BossHitParticle", 1f);
            isHit = true;
            audio.Play();
        }
        //첫 번째 기믹 모션 중 피격
        if (other.CompareTag("PlayerAttack") && ra.AtkTime1 == true)
        {
            currentHp -= 1;
            Destroy(other.gameObject);
            hitParticle.SetActive(true);
            Invoke("BossHitParticle", 1f);
            isHit_AtkTime1 = true;
            audio.Play();
        }
    }
}
