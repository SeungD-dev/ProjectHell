using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float currentPosition; //현재 위치(x) 저장
    float direction = 5.0f; //이동속도+방향
    float time;
    public bool stop = false;
    public GameObject[] boss;
    Vector3 position;
    Vector3[] randomPosition = {new Vector3(-13, 1, -6), new Vector3(-13, 1, -2), new Vector3(-13, 1, 2), new Vector3(-13, 1, 6)};
    BossRandomAttack bossRandomAttack;

    void Start()
    {
        position = this.gameObject.transform.position;
        currentPosition = this.gameObject.transform.position.z;
        bossRandomAttack = FindObjectOfType<BossRandomAttack>();
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

            if (this.gameObject.name == "Boss1")
            {
                Debug.Log("작동1");
                if(currentPosition >= position.z + 12)
                {
                    direction *= -1;
                    currentPosition = position.z + 12;
                }
                else if(currentPosition <= position.z)
                {
                    direction *= -1;
                    currentPosition = position.z;
                }
            }
            else if(this.gameObject.name == "Boss2")
            {
                Debug.Log("작동2");
                if (currentPosition >= position.z + 8)
                {
                    direction *= -1;
                    currentPosition = position.z + 8;
                }
                else if (currentPosition <= position.z + -4)
                {
                    direction *= -1;
                    currentPosition = position.z + -4;
                }
            }
            else if(this.gameObject.name == "Boss3")
            {
                Debug.Log("작동3");
                if (currentPosition >= position.z + 4)
                {
                    direction *= -1;
                    currentPosition = position.z + 4;
                }
                else if (currentPosition <= position.z + -8)
                {
                    direction *= -1;
                    currentPosition = position.z + -8;
                }
            }
            else if(this.gameObject.name == "Boss4")
            {
                Debug.Log("작동4");
                if (currentPosition >= position.z)
                {
                    direction *= -1;
                    currentPosition = position.z;
                }
                else if (currentPosition <= position.z + -12)
                {
                    direction *= -1;
                    currentPosition = position.z + -12;
                }
            }
            this.gameObject.transform.position = new Vector3(-13, 1, currentPosition);
        }
        else if (stop == true)
        {
            if(this.gameObject.name == "Boss1")
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, randomPosition[bossRandomAttack.positionList[0]], 0.02f);
            }
            else if (this.gameObject.name == "Boss2")
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, randomPosition[bossRandomAttack.positionList[1]], 0.02f);
            }
            else if (this.gameObject.name == "Boss3")
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, randomPosition[bossRandomAttack.positionList[2]], 0.02f);
            }
            else if (this.gameObject.name == "Boss4")
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, randomPosition[bossRandomAttack.positionList[3]], 0.02f);
            }
        }
    }
}
