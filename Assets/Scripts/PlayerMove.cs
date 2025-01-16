using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float speedPlayer = 3f;
    float moveInputX;
    float moveInputY;
    public Joystick joystick;
    public float xPos;
    public float yPos;

    Rigidbody2D rb;

    bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        moveInputX = joystick.Horizontal;
        moveInputY = joystick.Vertical;

        rb.velocity = new Vector2(speedPlayer * moveInputX, speedPlayer * moveInputY);
        xPos = transform.position.x;
        yPos = transform.position.y;


        if(facingRight && moveInputX < -0.1f)
        {
            Flip();
        }
        else if (!facingRight && moveInputX > 0.1f)
        {
            Flip();
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
       
    }

    public GameObject spawnBullet;
    public GameObject bulletPrefab;
    Inventory inventory;
    TMP_Text textInventory;
    public GameObject bulletUI;
    GameObject bullet;

    public void Shoot()
    {
        
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i])
            {
                if (inventory.slots[i].GetComponentInChildren<Spawn>().item.name == "5.45x39")
                {
                    //inventory.items[i] = GameObject.FindGameObjectWithTag("BulletInInventory");
                    bullet = Instantiate(bulletPrefab, spawnBullet.transform.position, Quaternion.identity);
                    if (facingRight)
                    {
                        bullet.transform.rotation = Quaternion.Euler(0, 0, -90f);
                    }
                    else if (!facingRight)
                    {
                        bullet.transform.rotation = Quaternion.Euler(0, 0, 90f);
                    }
                    textInventory = inventory.slots[i].GetComponentInChildren<TMP_Text>();
                    Debug.Log(i + " | " + inventory.count[i]);
                    inventory.count[i]--;
                    if (inventory.count[i] == 0)
                    {
                        Destroy(inventory.items[i]);
                        break;
                    }
                    textInventory.text = inventory.count[i].ToString();
                    break;
                }
            }
        }


    }

    
}
