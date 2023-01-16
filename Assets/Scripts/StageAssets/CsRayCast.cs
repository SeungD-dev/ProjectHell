using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CsRayCast : MonoBehaviour
{
	public Transform target;    // 부채꼴에 포함되는지 판별할 타겟
	public float angleRange = 30f;
	public float radius = 5f;

	Color _blue = new Color(0f, 0f, 1f, 0.2f);
	Color _red = new Color(1f, 0f, 0f, 0.2f);

	bool isCollision = false;


	public GameObject monster;
	ChasePlayer chasePlayer;
	float time;

	// ray의 길이
	[SerializeField]
	private float _maxDistance = 1.5f;

	// ray의 색상
	[SerializeField]
	private Color _rayColor = Color.red;

	public GameObject button;
	VirtualJoystick_Y virtualJoystick;

	public int count;

	private void Start()
    {
        chasePlayer = monster.GetComponent<ChasePlayer>();
		virtualJoystick = button.GetComponent<VirtualJoystick_Y>();
    }

    // Update is called once per frame
    void Update()
	{
		Vector3 interV = target.position - transform.position;

		// target과 나 사이의 거리가 radius 보다 작다면
		if (interV.magnitude <= radius)
		{
			// '타겟-나 벡터'와 '내 정면 벡터'를 내적
			float dot = Vector3.Dot(interV.normalized, transform.forward);
			// 두 벡터 모두 단위 벡터이므로 내적 결과에 cos의 역을 취해서 theta를 구함
			float theta = Mathf.Acos(dot);
			// angleRange와 비교하기 위해 degree로 변환
			float degree = Mathf.Rad2Deg * theta;

			// 시야각 판별
			if (degree <= angleRange / 2f)
			{ 
				chasePlayer.goMonster = false;
				time = 0;
			}
            else
            {
				if (time >= 3f)
					chasePlayer.goMonster = true;
				time += Time.deltaTime;
			}
		}
		else
        {
			if (time >= 3f)
				chasePlayer.goMonster = true;
			time += Time.deltaTime;
		}	
	}
	private void OnDrawGizmos()
	{
		Handles.color = isCollision ? _red : _blue;
		// DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);


		Gizmos.color = _rayColor;

		// 함수 파라미터 : Capsule의 시작점, Capsule의 끝점, Capsule의 크기(x, z 중 가장 큰 값이 크기가 됨), Ray의 방향, RaycastHit 결과, Capsule의 회전값, CapsuleCast를 진행할 거리
		if (true == Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance))
		{
			// Hit된 지점까지 ray를 그려준다.
			Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
			virtualJoystick.moveSpeed = 0f;
		}
		else
		{
			// Hit가 되지 않았으면 최대 검출 거리로 ray를 그려준다.
			Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
			virtualJoystick.moveSpeed = 7;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
			count++;
			Debug.Log(count);
			Destroy(other.gameObject);
		}
    }
}