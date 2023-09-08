using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 10;

    public bool IsMovingRight = true;

    public float LeftBoundry;
    public float RightBoundry;

    private void Start()
    {
        LeftBoundry += transform.position.x; //Or LeftBoundry += transform.position.x
        RightBoundry += transform.position.x; //Or RightBoundry += transform.position.x

        Debug.Log("test start enemy evil");
    }

    void Update()
    {
        if (IsMovingRight)
        {
            transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;

        }

        else
        {
            transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x >= RightBoundry)
        {
            IsMovingRight = false;
        }

        if (transform.position.x <= LeftBoundry)
        {
            IsMovingRight = true;
        }

       
        
    }
}
