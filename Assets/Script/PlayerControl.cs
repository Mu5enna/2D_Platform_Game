using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D playerRB;
    Animator playerA;
    public float moveSpeed = 1;
    public float jumpForce = 1, jumpFrequency = 1, jumpTime;
    bool lookingRight = true;
    public bool isGround = true;
    public Transform gCheckPos;
    public float gCheckRad;
    public LayerMask gCheckLayer;
    // Start is called before the first frame update
    void Start()
    {
        playerA=GetComponent<Animator>();
        playerRB= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        HorizontalMOve();
        Jump();
        turnFace();
    }

    void HorizontalMOve()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerA.SetFloat("PlayerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void turnFace()
    {
        if (playerRB.velocity.x < 0 && lookingRight) 
        {
            lookingRight = false;
            Vector3 tempLS = transform.localScale;
            tempLS.x *= -1;
            transform.localScale = tempLS;
        }
        else if(playerRB.velocity.x > 0 && !lookingRight)
        {
            lookingRight = true;
            Vector3 tempLS=transform.localScale;
            tempLS.x *= -1;
            transform.localScale = tempLS;
        }
    }

    void Jump()
    {
        if (Input.GetAxis("Vertical") > 0 && GroundCheck() && (jumpTime<Time.timeSinceLevelLoad))  
        {
            jumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
    }

    bool GroundCheck()
    {
        isGround =  Physics2D.OverlapCircle(gCheckPos.position, gCheckRad, gCheckLayer);
        playerA.SetBool("isJump", !isGround);
        playerA.SetBool("isJump", !isGround);
        return isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TriggerZone")
        {
            playerRB.AddForce(new Vector2(0,jumpForce));
        }
    }
}
