//Author: Adam White
//Date created: 10/15/2022
//Date of last change: 10/15/2022
//Purpose: Create a simple object pool and instantiate all the water objects.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoolManager : MonoBehaviour
{
    public GameObject waterPrefab; //Assign in the inspector.
    public static Queue<GameObject> waterPool;
    const int POOL_SIZE = 50; //The max number of waterTiles that will be in the game.

    void Start()
    {
        waterPool = new Queue<GameObject> ();

        //Instantiate all the objects before the game starts
        for(int i = 0; i < POOL_SIZE; i++)
        {
            GameObject water = Instantiate(waterPrefab);
            water.SetActive(false);
            waterPool.Enqueue(water);
        }
    }
}
