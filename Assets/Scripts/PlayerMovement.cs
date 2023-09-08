using System;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float JumpSpeed = 500f;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded = false;

    #region Input Variables

    private float _XInput;
    private bool _isJumpPressed = false;
    
    #endregion

    void Start()
    {
        Debug.Log("test start player momveme");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Debug.Log("test update player movement");
        //Key board A/D or Left/Right arrow
        //Controller stick Left/Right??
        _XInput = Input.GetAxisRaw("Horizontal");
        //_XInput *= MoveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
    }

    private void FixedUpdate()    
    {
        //_rigidbody.AddForce(new Vector2(_XInput, 0f), ForceMode2D.Force);

        _rigidbody.velocity = new Vector2(_XInput * MoveSpeed * Time.deltaTime, _rigidbody.velocity.y);

        if (_isJumpPressed && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        _isJumpPressed = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}

