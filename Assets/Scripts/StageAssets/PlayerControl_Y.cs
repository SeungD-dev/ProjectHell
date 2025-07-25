using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl_Y : MonoBehaviour
{
    [SerializeField] float jumpForce;

    public Vector3 player_Pos;

    private Rigidbody rb;

    public SpriteRenderer ganglim;

    GameObject jumpBtn, leftBtn, rightBtn;

    bool jumpAllowed = true;
    bool isJumping = false;

    private Vector3 MoveDir;

    PlayerHP playerhp;

    bool isHurt;
    private float fTickTime;
    private float fDestroyTime = 5f;

    AttackEvent attackEvent;

    Color HalfA = new Color(1, 1, 1, 0.5f);
    Color FullA = new Color(1, 1, 1, 1);

    bool flip;
    float time = 0;
    bool jumpCC;

    // Start is called before the first frame update
    void Start()
    {
        jumpBtn = GameObject.Find("JumpButton");
        leftBtn = GameObject.Find("LButton");
        rightBtn = GameObject.Find("RButton");



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
        time += Time.deltaTime;
        fTickTime += Time.deltaTime;
        if (time >= 5f && time < 10f)
        {
            flip = true;
            jumpCC = true;
            jumpAllowed = false;
        } else
        {
            flip = false;
            jumpCC = false;
        }

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
            if (fTickTime >= fDestroyTime)
            {
                // StartCoroutine(HurtCooldown());
                playerhp.IncreaseHP(1);
                fTickTime = 0;
            }
        }
    }

    public void JumpTouched()
    {
        if (!jumpAllowed && !jumpCC)
        {
            jumpAllowed = true;

            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            gameObject.layer = 7;
        }

    }

    public void LButtonDown()
    {
        if (gameObject.transform.position.x > -0.89 && flip == false)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0.3f, 0);
        }
        else if (gameObject.transform.position.x < 0.89 && flip == true)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0.3f, 0);
        }
    }
    public void RButtonDown()
    {
        if (gameObject.transform.position.x < 0.89 && flip == false)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0.3f, 0);
        }
        else if (gameObject.transform.position.x > -0.89 && flip == true)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0.3f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && !jumpCC)
        {
            gameObject.layer = 6;
            jumpAllowed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X") 
            || other.CompareTag("BossAttack") || other.CompareTag("BossAttack_Up") || other.CompareTag("BossAttack_Down") ||
             other.CompareTag("SwordTrail") || other.CompareTag("SwordTrail_Vertical"))
        {
            Destroy(other.gameObject);
            if (!isHurt)
            {
                Hurt();
                fTickTime = 0f;
                StartCoroutine(HurtCooldown());
                StartCoroutine(GanglimHurtdown());
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

    IEnumerator HurtCooldown()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("실행");
        isHurt = false;
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
