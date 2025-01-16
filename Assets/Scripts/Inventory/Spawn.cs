using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public void SpawnDroppedItem()
    {
        Instantiate(item, player.position, Quaternion.identity);
    }
}
