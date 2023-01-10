using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerPos;

    public float monsterSpeed = 0.05f;

    public bool goMonster;

    private void Start()
    {
        goMonster = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (goMonster == true)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPos.localPosition, monsterSpeed);
    }
}
