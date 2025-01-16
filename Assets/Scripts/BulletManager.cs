using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    Rigidbody2D rb;
    float speedBullet = 20f;
    public float damageBullet = 20f;
    public GameObject drop;
    HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speedBullet;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthBar = collision.gameObject.GetComponentInChildren<HealthBar>();
            healthBar.Damage(damageBullet);
            if (healthBar.health <= 0)
            {
                Instantiate(drop,collision.gameObject.transform.position,Quaternion.identity);
                Destroy(collision.gameObject);
                
            }
            Destroy(gameObject);
            
        }
    }
}

