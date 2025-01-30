using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed ;
    private Rigidbody2D enemyBody;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        EnemyMovement();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        { 
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
             PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
             Transform PlayerPosition = collision.gameObject.transform;
             transform.localScale = new Vector2(-Mathf.Sign(PlayerPosition.localScale.x), PlayerPosition.localScale.y);
             animator.SetBool("Attack", true);
             enemyBody.velocity = new Vector2(0, 0);
             playerController.DamagePlayer();
             }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Attack", false);
        EnemyMovement();
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "platform")
        {
            transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), transform.localScale.y);
        }
    }



    private void EnemyMovement()
    {
        if (facingRight())
        {
            enemyBody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyBody.velocity = new Vector2(-speed, 0);
        }
    }

    private bool facingRight()
    {
        return transform.localScale.x > 0.1;
    }
}
