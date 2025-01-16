using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDataSpace
{

    [Serializable]
    public class GameData
    {
        public Vector3 playerPosition;

        public Vector3 enemy1Position;
        public Vector3 enemy2Position;
        public Vector3 enemy3Position;
        public Vector3 enemy4Position;

        //Items
        public Vector3[] bulletPrefSpawn;

        //Inventory
        public string[] named = new string[4];
        public int[] count = new int[4];
        public bool[] isFull = new bool[4];
        
    }
}
