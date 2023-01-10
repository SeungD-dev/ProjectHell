using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CsRayCast : MonoBehaviour
{
	ChasePlayer chasePlayer;
    private void Start()
    {
        chasePlayer = GetComponent<ChasePlayer>();
    }

    // Update is called once per frame
    void Update()
	{
		Debug.DrawRay(transform.position, transform.forward * 8, Color.red);

		//  레이캐스트가 빨간줄로 실제로 보게 만들어 준다.

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
		// (시작점,방향 ,hit info,거리)
		{
			Debug.Log(hit.collider.gameObject.name);
			// 광선이 충돌한 오브젝트를 로그창에 보여 준다.
			chasePlayer.goMonster = false;
		}
		else chasePlayer.goMonster = true;

	}
}