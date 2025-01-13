using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float Jump;
    private Animator animator;
    private Rigidbody2D rd2d;
    private bool isGrounded = false;
    private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    // Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private void Awake()
    {
        Debug.Log("Player script is activated");
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Fetching initial collider properties
        boxColInitSize = new Vector2(0.4295021f, 2.054952f);
        boxColInitOffset = new Vector2(-0.01529616f, 0.9386219f);
        boxCol.size = boxColInitSize;
        boxCol.offset = boxColInitOffset;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        // Check for crouch input
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x); // player run animation
        }
        transform.localScale = scale;

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else // player jump animation
        {
            animator.SetBool("Jump", false);
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 Position = transform.position;
        Position.x += horizontal * speed * Time.deltaTime;
        transform.position = Position; // moving player horizontally
        if (vertical > 0 && isGrounded)
        {
            playerAnimator.SetTrigger("Jump");
            rd2d.AddForce(new Vector2(0f, Jump), ForceMode2D.Force);
            Debug.Log("Jumping");
        }
        Debug.Log("isGrounded: " + isGrounded);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
            //Debug.Log("Touching platform: " + other.transform.name);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
            //Debug.Log("Left platform: " + other.transform.name);
        }
    }

    private void Crouch(bool crouch)
    {
        if (crouch)
        {
            float offX = -0.0978f;     // Offset X
            float offY = 0.5947f;      // Offset Y

            float sizeX = 0.6988f;     // Size X
            float sizeY = 1.3398f;     // Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   // Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   // Setting the offset of collider
        }
        else
        {
            // Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        // Play Crouch animation
        playerAnimator.SetBool("Crouch", crouch);
    }
   
}
