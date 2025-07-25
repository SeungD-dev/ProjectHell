using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //터치와 관련된 인터페이스를 가져올 거임
                                //마우스 클릭 시작했을 때  //마우스 손 땠을 때  //드래그 했을 때
public class VirtualJoystick_6 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //이 스크립트는 백그라운드에 어사인 해줌
    //터치에 반응할 부분은 백그라운드이기 때문

    //움직이는 범위를 제한하기 위해서 선언함
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;

    //백그라운드의 반지름의 범위를 저장시킬 변수
    private float radius;

    //화면에서 움직일 플레이어
    [SerializeField] public GameObject go_Player;
    //움직일 속도
    [SerializeField] public float moveSpeed;

    //터치가 시작됐을 때 움직이거라
    private bool isTouch = false;
    //움직일 좌표
    public Vector3 movePosition;

    //private Animation anim;
    //캐릭터 회전값을 만들기위해 value를 전역변수로 설정함
    private Vector2 value;

    public float width = 0.5f;

    public GameObject ViewCamera = null;

    void Start()
    {
        //inspector에 그 rect Transform에 접근하는 거 맞음
        //0.5를 곱해서 반지름을 구해서 값을 넣어줌
        this.radius = rect_Background.rect.width * width;
    }

    //이동 구현
    void Update()
    {
        RaycastHit m_Hit;
        if (this.isTouch)
        {
            Debug.Log("fdsfsd");
            this.go_Player.transform.position += this.movePosition;
            //조이스틱 방향으로 캐릭터 회전
            if (this.value != null)
            {
                this.go_Player.transform.rotation = Quaternion.Euler(0f,
                Mathf.Atan2(this.value.x, this.value.y) * Mathf.Rad2Deg, 0f);
            }
        }

        Debug.DrawLine(go_Player.transform.position, ViewCamera.transform.position, Color.red);
        Vector3 direction = new Vector3(0, 7, -5);

        if (Physics.Linecast(go_Player.transform.position, ViewCamera.transform.position, out m_Hit))
        {
            ViewCamera.transform.position = m_Hit.point;
        }
        else
        {
            ViewCamera.transform.position = direction + go_Player.transform.position;
        }
    }



    //인터페이스 구현

    //눌렀을 때(터치가 시작됐을 때)
    public void OnPointerDown(PointerEventData eventData)
    {
        this.isTouch = true;
    }

    //손 땠을 때
    public void OnPointerUp(PointerEventData eventData)
    {
        //손 땠을 때 원위치로 돌리기
        rect_Joystick.localPosition = Vector3.zero;

        this.isTouch = false;
        //움직이다 손을 놓았을 때 다시 클릭하면 방향 진행이 되는 현상을 고침
        this.movePosition = Vector3.zero;

        //this.anim.Play("idle@loop");
    }

    //드래그 했을때
    public void OnDrag(PointerEventData eventData)
    {
        //마우스 포지션(x축, y축만 있어서 벡터2)
        //마우스 좌표에서 검은색 백그라운드 좌표값을 뺀 값만큼 조이스틱(흰 동그라미)를 움직일 거임
        this.value = eventData.position - (Vector2)rect_Background.position;

        //가두기
        //벡터2인 자기자신의 값만큼, 최대 반지름만큼 가둘거임
        value = Vector2.ClampMagnitude(value, radius);
        //(1,4)값이 있으면 (-3 ~ 5)까지 가두기 함

        //부모객체(백그라운드) 기준으로 떨어질 상대적인 좌표값을 넣어줌
        rect_Joystick.localPosition = value;

        //value의 방향값만 구하기
        value = value.normalized;
        //x축에 방향에 속도 시간을 곱한 값
        //y축에 0, 점프 안할거라서
        //z축에 y방향에 속도 시간을 곱한 값

        this.movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime,
                                    0f,
                                    value.y * moveSpeed * Time.deltaTime);
    }
}
