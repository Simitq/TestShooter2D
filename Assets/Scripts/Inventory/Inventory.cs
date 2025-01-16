using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject[] items;
    public int[] count;
    public string[] named;
    public GameObject backpackPanel;
    bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    public void Chest()
    {
        if(isOpen)
        {
            backpackPanel.SetActive(false);
            isOpen = false;
        }
        else if (!isOpen)
        {
            backpackPanel.SetActive(true);
            isOpen = true;
        }
    }
}
