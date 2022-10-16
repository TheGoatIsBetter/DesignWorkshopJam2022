using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public List<FireSpawner> fireSpawnerList;

    [SerializeField] private int minRange;
    [SerializeField] private int maxRange;
    [SerializeField] private int minForCheck;

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
            if (Random.Range(minRange, maxRange) > minForCheck)
            {
                fireSpawner.SpawnFire();
            }
        }
    }
}
