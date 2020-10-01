using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConttroller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency=1f, nextJumptime;

    bool facingright = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        if (playerRB.velocity.x < 0 && facingright)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingright)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical")> 0 && isGrounded && (nextJumptime < Time.timeSinceLevelLoad))
        {
            nextJumptime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void FixedUpdate()
    {

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed",Math.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingright = !facingright;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim",isGrounded);
    }

}
