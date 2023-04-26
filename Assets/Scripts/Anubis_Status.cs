using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anubis_Status : MonoBehaviour
{
    public int AnubisHP = 5;
    public float AnubisHPtime = 90;
    public Sprite[] sprites;
    int sprite_index;
   
    public SpriteRenderer spriteRenderer;
    public AudioSource anubisHitSound, anubisDeadSound;
    public GameObject hitParticle;
    public GameObject Line;
    public bool isHit = false;

    Scene scene;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite_index = 0;
        scene = SceneManager.GetActiveScene();
        hitParticle.SetActive(false);
    }

   
    void Update()
    {
        AnubisHPtime -= Time.deltaTime;

        if(AnubisHP <= 0)
        {
            Line.SetActive(false);
            Debug.Log("아누비스 죽음");
            GameResultButton.clear = scene.name;
            Invoke("LoadScene", 1f);
        }
        if(AnubisHPtime <= 0)
        {
            Line.SetActive(false);
            Debug.Log("아누비스 죽음");
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
            if(AnubisHP >= 4)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                //StartCoroutine(BossHitImage());
                Debug.Log("아누비스 체력 : " + AnubisHP);
                isHit = true;
                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();

            }
            else if(AnubisHP <= 3)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                //StartCoroutine(BossHitImageLowHP());
                isHit = true;
                Debug.Log("아누비스 체력 : " + AnubisHP);

                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();
            }
            if(AnubisHP == 0)
            {
                //spriteRenderer.sprite = sprites[sprite_index];
                Destroy(other.gameObject);

                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();
            }
            hitParticle.SetActive(true);
            Invoke("BossHitParticle", 1f);
        }
    }

    void BossHitParticle()
    {
        hitParticle.SetActive(false);
    }

    IEnumerator BossHitImage()
    {
        sprite_index = 1;
        spriteRenderer.sprite = sprites[sprite_index];
        yield return new WaitForSeconds(0.8f);
        sprite_index = 0;
        spriteRenderer.sprite = sprites[sprite_index];
    }

    IEnumerator BossHitImageLowHP()
    {
        sprite_index = 1;
        spriteRenderer.sprite = sprites[sprite_index];
        yield return new WaitForSecondsRealtime(0.8f);
        sprite_index = 2;
        spriteRenderer.sprite = sprites[sprite_index];
        
    }
}
