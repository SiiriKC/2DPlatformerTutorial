using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera PlayerCamera;
    public Transform Crosshair;
    public GameObject BulletPrefab;

    private void Start(){

        Debug.Log("test start");       

        if (PlayerCamera == null){

            PlayerCamera = Camera.main;
        }
        if (PlayerCamera == null){

            PlayerCamera = FindObjectOfType<Camera>();
        }
    }
        
    void Update()
    {
        Vector3 mousePosition = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        Debug.Log("test");

        if (Crosshair != null)
        {
            Debug.Log("test 2");


            Crosshair.position = mousePosition;

        }

        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("test 3");

            //The direction To A from B == A-B (destination - origin = the direction)   
            Vector3 directionToMouse = mousePosition - transform.position;
         float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
         Quaternion bulletRotation = Quaternion.Euler(0,0,angle - 90);

         //Default rotation/ no rotation = Quaternion.identity.
         //Quaternion is how unity deals with rotations.
         Instantiate(BulletPrefab, transform.position, bulletRotation);

        }
    }
}
