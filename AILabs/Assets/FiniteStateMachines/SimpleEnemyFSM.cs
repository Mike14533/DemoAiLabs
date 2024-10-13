using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyFSM : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;

    public enum EnemyState
    {
        CHASE,
        IDLE
    };

    public EnemyState currentState = EnemyState.CHASE;



    // Update is called once per frame
    void Update()
    {

        float range0 = Vector3.Distance(target.transform.position, transform.position);

        if (range0 >= 1){
            Idle();
            speed = 0f;
        }
        else
        {
            BasicChase();
            speed = 1f;
        }

        switch (currentState)
        {
            case EnemyState.CHASE:
                BasicChase();
                break;
            case EnemyState.IDLE:
                Idle();
                break;
        }
    }

    void BasicChase()
    {
        float speedDelta  = speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - target.transform.position.x) > speedDelta)
        {
            if (transform.position.x > target.transform.position.x)
            {
                float deltax = -speedDelta;
                transform.Translate(new Vector3(deltax, 0, 0));
            }
            else if (transform.position.x < target.transform.position.x)
            {
                float deltax = speedDelta;
                transform.Translate(new Vector3(deltax, 0, 0));
            }
        }

        if (Mathf.Abs(transform.position.y - target.transform.position.y) > speedDelta)
        {
            if (transform.position.y > target.transform.position.y)
            {
                float deltay = -speedDelta;
                transform.Translate(new Vector3(0, deltay, 0));
            }
            else if (transform.position.y < target.transform.position.y)
            {
                float deltay = speedDelta;
                transform.Translate(new Vector3(0, deltay, 0));
            }
        }
    }

    void Idle()
    {

    }
}






