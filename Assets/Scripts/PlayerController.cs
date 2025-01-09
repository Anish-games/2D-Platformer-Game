using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rd2d;
    public float Jump;
    private bool isGrounded = false;
    private Animator playerAnimator;
    private void Awake()
    {
        Debug.Log("Player script is activated");
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayMovementAnimation(horizontal , vertical);
        MoveCharacter(horizontal, vertical);


        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    Crouch(true);
        //}
        //else
        //{
        //    Crouch(false);
        //}


    }

    private void PlayMovementAnimation(float horizontal , float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);       // player run animation.
        }
        transform.localScale = scale;

        
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else                                  // player jump animation.
        {
            animator.SetBool("Jump",false);
        }

    }


    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 Position = transform.position;
        Position.x += horizontal * speed * Time.deltaTime;
        transform.position = Position;                       // moving player horizontally.
        if (vertical > 0 && isGrounded)
        {
            playerAnimator.SetTrigger("Jump");
            rd2d.AddForce(new Vector2(0f,Jump),ForceMode2D.Force);
            Debug.Log("Jumping");
        }
        Debug.Log("isGrounded: " + isGrounded);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }
   private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
        }
    }
   



        //public void Crouch(bool crouch)
        //{
        //    animator.SetBool("IsCrouch", crouch);
        //}


}
