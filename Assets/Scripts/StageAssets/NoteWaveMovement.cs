using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteWaveMovement : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;

    Vector3 pos, localScale;



    
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

   
    void Update()
    {
        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();

        //transform.localPosition = Vector3.back * moveSpeed * Time.deltaTime;
    }

    void CheckWhereToFace()
    {
        if (pos.x < -2f)
            facingRight = true;
        else if (pos.x > 2f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + Vector3.back * Mathf.Sin(Time.time * frequency) * magnitude;
    }
    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + Vector3.back * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
