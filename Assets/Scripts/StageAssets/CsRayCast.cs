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

	public int count;

	private void Start()
    {
        chasePlayer = monster.GetComponent<ChasePlayer>();
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
	#if UNITY_Editor
	private void OnDrawGizmos()
	{
		Handles.color = isCollision ? _red : _blue;
		// DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
	}
	#endif

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