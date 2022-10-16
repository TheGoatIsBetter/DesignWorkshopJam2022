using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public List<FireSpawner> fireSpawnerList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomFires()
    {
        
        foreach(FireSpawner fireSpawner in fireSpawnerList)
        {
            Debug.Log("ddd");
            if (Random.Range(0,100) > 50)
            {
                fireSpawner.SpawnFire();
            }
        }
    }
}
