using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float rightMax; //좌로 이동가능한 (x)최대값
    float leftMax; //우로 이동가능한 (x)최대값
    float currentPosition; //현재 위치(x) 저장
    float direction = 3.0f; //이동속도+방향
    float cRight;
    float cLeft;
    float time;
    public bool stop = false;
    Vector3 position;

    void Start()
    {
        position = this.gameObject.transform.position;
        currentPosition = this.gameObject.transform.position.x;
        cRight = Random.Range(0.1f, 3);
        cLeft = Random.Range(0.1f, 3) * -1;
        rightMax = cRight + this.gameObject.transform.position.z;
        leftMax = cLeft + this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 4)
            stop = true;
        if (!stop)
        {
            currentPosition += Time.deltaTime * direction;
            if (currentPosition >= rightMax)
            {
                direction *= -1;
                currentPosition = rightMax;
            }
            //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
            //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정
            else if (currentPosition <= leftMax)
            {
                direction *= -1;
                currentPosition = leftMax;
            }

            //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
            //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1, currentPosition);
            //"Stone"의 위치를 계산된 현재위치로 처리
        }
        else if (stop == true)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, position, 0.01f);
        }
    }
}
