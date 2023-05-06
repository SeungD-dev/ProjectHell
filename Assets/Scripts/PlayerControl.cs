using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    
    public Vector3 player_Pos;
   
    private Rigidbody rb;

    public SpriteRenderer ganglim;
    public GameObject hitParticle;
    
    GameObject jumpBtn, leftBtn, rightBtn;

    bool jumpAllowed = true;
    bool isJumping = false;
    bool isJump = false;
    private Vector3 MoveDir;

    PlayerHP playerhp;

    bool isHurt;
    bool isSound = true;
    private float fTickTime;
    private float fDestroyTime = 5f;

    AttackEvent attackEvent;

    Color HalfA = new Color(1, 1, 1, 0.5f);
    Color FullA = new Color(1, 1, 1, 1);

    public bool flip;
    public bool jumpCC;
    public int jumpC, leftC, rightC = 0;

    public AudioSource playerhitSound;

  

    // Start is called before the first frame update
    void Start()
    {
        jumpBtn = GameObject.Find("JumpButton");
        leftBtn = GameObject.Find("LButton");
        rightBtn = GameObject.Find("RButton");

        hitParticle.SetActive(false);

        flip = false;
        jumpCC = false;
       
        rb = GetComponent<Rigidbody>();
        MoveDir = Vector3.zero;

        playerhp = FindObjectOfType<PlayerHP>();
        attackEvent = FindObjectOfType<AttackEvent>();

        Renderer rd = this.GetComponent<MeshRenderer>();
        Material[] mat = rd.sharedMaterials;
    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;
        player_Pos = gameObject.transform.position;
        
        if (jumpAllowed == false)
        {
            jumpBtn.GetComponent<Button>().interactable = true;
        }
        if (jumpAllowed == true)
        {
            jumpBtn.GetComponent<Button>().interactable = false;
        }

        /*if(playerhp.player_currentHP == 0)
        {
            //강림이 죽었을 때 내용 넣기
        }*/
        

        if (playerhp.player_currentHP != playerhp.player_MaxHP)
        {
            if(fTickTime >= fDestroyTime)
            {
                // StartCoroutine(HurtCooldown());
                playerhp.IncreaseHP(1);
                fTickTime = 0f;
            }
        }
    }

    public void JumpTouched()
    {
        if (!jumpAllowed && !jumpCC)
        {
            jumpAllowed = true;
            jumpC++;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
            //gameObject.layer = 7;
        }
    }

    public void LButtonDown()
    {
        if (gameObject.transform.position.x > -0.89 && flip == false && isJump == false)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0.3f, 0);
            leftC++;
        }
        else if (gameObject.transform.position.x < 0.89 && flip == true)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0.3f, 0);
            leftC++;
        }
        else if (gameObject.transform.position.x > -0.89 && flip == false && isJump == true)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0, 0);
            leftC++;
        }
    }
    public void RButtonDown()
    {
        if (gameObject.transform.position.x < 0.89 && flip == false && isJump == false)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0.3f, 0);
            rightC++;
        }
        else if (gameObject.transform.position.x > -0.89 && flip == true)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0.3f, 0);
            rightC++;
        }
        else if(gameObject.transform.position.x < 0.89 && flip == false && isJump == true)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0, 0);
            rightC++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.layer = 6;
            jumpAllowed = false;
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X") ||
            other.CompareTag("SwordTrail") || other.CompareTag("SwordTrail_Vertical") || other.CompareTag("Note_BB") || other.CompareTag("Note_BG") || other.CompareTag("Note_BR"))
        {
            Destroy(other.gameObject);
            if (!isHurt)
            {
                Hurt();
                hitParticle.SetActive(true);
                fTickTime = 0f;
                StartCoroutine(HurtCooldown());
                StartCoroutine(GanglimHurtdown());
                PlayerHitSound();
                StartCoroutine(SoundRoutine());
            }          
            Debug.Log(playerhp.player_currentHP);
        }
        else if (other.CompareTag("UnderFloor"))
        {
            Hurt();
            Debug.Log(playerhp.player_currentHP);
        }     
    }

    public void Hurt()
    {
        if (!isHurt)
        {
            isHurt = true;
            playerhp.DecreaseHP(1);
            Debug.Log("ㅇㅇㅇㅇ");
            fTickTime = 0;
        }
    }

    public void PlayerHitSound()
    {
        if (isSound)
        {
            isSound = false;
            playerhitSound.Play();
        }
    }

    IEnumerator HurtCooldown()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("실행");
        isHurt = false;
        hitParticle.SetActive(false);
    }

    IEnumerator SoundRoutine()
    {
        yield return new WaitForSeconds(1f);
        isSound = true;
    }
    IEnumerator GanglimHurtdown()
    {
        ganglim.color = HalfA;
        yield return new WaitForSeconds(0.2f);
        ganglim.color = FullA;
        yield return new WaitForSeconds(0.2f);
        ganglim.color = HalfA;
        yield return new WaitForSeconds(0.2f);
        ganglim.color = FullA;
        yield return new WaitForSeconds(0.2f);
        ganglim.color = HalfA;
        yield return new WaitForSeconds(0.2f);
        ganglim.color = FullA;
    }
}
