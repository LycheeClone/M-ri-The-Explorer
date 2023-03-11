using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _playerRb;
    Animator _playerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFruquency = 1f, nextJumpTime;
    public bool _facingRight = true;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundChecklayer;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (_playerRb.velocity.x < 0 && _facingRight)
        {
            FlipFace();
        }
        else if (_playerRb.velocity.x > 0 && !_facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFruquency;
            Jump();
        }

        void HorizontalMove()
        {
            _playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _playerRb.velocity.y);
            _playerAnimator.SetFloat("playerSpeed", Mathf.Abs(_playerRb.velocity.x));
        }

        void FlipFace()
        {
            _facingRight = !_facingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }

        void Jump()
        {
            _playerRb.AddForce(new Vector2(0, jumpSpeed));
        }

        void OnGroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundChecklayer);
            _playerAnimator.SetBool("isGroundedAnim", isGrounded);
        }
        //float moveSpeed = 10;       
        //float InputX = Input.GetAxis("Horizontal");
        ////Get the value of the Horizontal input axis.
        //float InputY = Input.GetAxis("Vertical");
        ////Get the value of the Vertical input axis.
        //transform.Translate(new Vector2(InputX, InputY) * moveSpeed * Time.deltaTime);
        ////Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }
}