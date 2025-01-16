using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject[] spawnPoints;
    int k = 0;
    int r;

    private void Start()
    {
        while (k < 3)
        {
            r = Random.Range(0, spawnPoints.Length);
            
            Instantiate(enemy1,new Vector2(
                spawnPoints[r].transform.position.x + Random.Range(1, 4),
                spawnPoints[r].transform.position.y + Random.Range(1, 4))      
                , Quaternion.identity);
            
            k++;
        }
        
    }
}
