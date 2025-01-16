using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float speedEnemy;
    Rigidbody2D rb;
    Transform targetPlayer;
    Animator animator;
    Image playerHealth;
    HealthBar healthBarPlayer;

    public int damage;
    bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthBarPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HealthBar>();
        
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyTrigger" && !animator.GetBool("isAttack"))
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speedEnemy * Time.deltaTime);
            if(transform.position.x > targetPlayer.position.x && facingRight)
            {
                facingRight = false;
                transform.Rotate(0f, 180f, 0f);
                
            }
            if (transform.position.x < targetPlayer.position.x && !facingRight)
            {
                facingRight = true;
                transform.Rotate(0f, 180f, 0f);
               
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ZoneEmenyAttack")
        {
            
            AttackStartAnim();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void Attack()
    {
        healthBarPlayer.Damage(damage);
        
    }

    public void AttackStartAnim()
    {
        animator.SetBool("isAttack", true);
    }
    public void AttackEndAnim()
    {
        animator.SetBool("isAttack", false);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
