using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    int maxCount;
    TMP_Text text;
    

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        maxCount = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true && gameObject.tag == "Bullet" && inventory.count[i] < maxCount)
                {
                    inventory.count[i]++;
                    text = inventory.slots[i].GetComponentInChildren<TMP_Text>();
                    text.text = inventory.count[i].ToString();
                    Destroy(gameObject);
                    break;
                }
                else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    if(gameObject.tag == "Bullet")
                    {
                        inventory.count[i]++;
                    }
                    inventory.items[i] = Instantiate(slotButton, inventory.slots[i].transform);
                    inventory.named[i] = slotButton.name;
                    
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
