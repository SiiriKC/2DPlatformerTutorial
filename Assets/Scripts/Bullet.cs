using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    public int Damage = 50;
    void Update()
    {

        Debug.Log("test bullet start");     
        transform.position += transform.up * (Speed * Time.deltaTime); //also can write Vector3.up
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
            
    }
}
