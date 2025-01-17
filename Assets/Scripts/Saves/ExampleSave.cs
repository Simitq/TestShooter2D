using GameDataSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExampleSave : MonoBehaviour
{
    private Storage storage;
    private GameData gameData;

    public GameObject player;
    PlayerMove playerMove;

    public GameObject[] enemy;

    public Inventory inventory;

    GameObject[] bulletItem;
    

    private void Start()
    {
        storage = new Storage();
        playerMove = player.GetComponent<PlayerMove>();

        Load();
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Save();
        if (Input.GetKeyDown(KeyCode.L))
            Load();

    }
    public void Save()
    {
        bulletItem = GameObject.FindGameObjectsWithTag("Bullet");
        Array.Resize(ref gameData.bulletPrefSpawn, bulletItem.Length);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; i++)
        {
            Vector3 position = enemy[i].transform.position;
            if(i == 0)
                gameData.enemy1Position = position;
            if (i == 1)
                gameData.enemy2Position = position;
            if (i == 2)
                gameData.enemy3Position = position;
            if (i == 3)
                gameData.enemy4Position = position;
        }
        for(int i = 0; i < bulletItem.Length; i++)
        {
            gameData.bulletPrefSpawn[i] = bulletItem[i].transform.position;
        }

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            
            if (inventory.named[i] != null)
            {
                Debug.Log(inventory.named[i] + "  | " + inventory.count[i]);
                gameData.named[i] = inventory.named[i];
                gameData.count[i] = inventory.count[i];
                gameData.isFull[i] = inventory.isFull[i];
                
                
            }
        }
        
        gameData.playerPosition = player.transform.position;
        storage.Save(gameData);
        Debug.Log("Game save");
    }
    public void Load()
    {
        gameData = (GameData)storage.Load(new GameData());
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        bulletItem = GameObject.FindGameObjectsWithTag("Bullet");
        if (gameData.bulletPrefSpawn.Length > 0)
            for (int i = 0; i < bulletItem.Length; i++)
            {
                Destroy(bulletItem[i]);
            }
        player.transform.position = gameData.playerPosition;
        
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].transform.position != null)
            {
                if (i == 0)
                    enemy[i].transform.position = gameData.enemy1Position;
                if (i == 1)
                    enemy[i].transform.position = gameData.enemy2Position;
                if (i == 2)
                    enemy[i].transform.position = gameData.enemy3Position;
                if (i == 3)
                    enemy[i].transform.position = gameData.enemy4Position;
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            
            Destroy(inventory.items[i]);
            if (gameData.named[i] != "" && gameData.count[i] != 0)
            {
                
                inventory.count[i] = gameData.count[i];
                inventory.named[i] = gameData.named[i];
                inventory.isFull[i] = gameData.isFull[i];
                Debug.Log(inventory.named[i] + "  | " + inventory.count[i]);
                inventory.items[i] = Instantiate(Resources.Load<GameObject>(gameData.named[i]), inventory.slots[i].transform);
                
            }
        }
        for (int i = 0; i < gameData.bulletPrefSpawn.Length; i++)
        {
            Instantiate(Resources.Load<GameObject>("5.45x39"), 
                new Vector3
                ( 
                    gameData.bulletPrefSpawn[i].x,
                    gameData.bulletPrefSpawn[i].y,
                    gameData.bulletPrefSpawn[i].z
                ),
                Quaternion.identity);
        }

    }
}
