using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private GameObject fireObject;
    public Fire fire;

    public bool isOccupied = false;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.fireManager.fireSpawnerList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFire()
    {
        isOccupied = true;

        //spawn object
        fireObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

        //set fire ref
        fire = fireObject.GetComponent<Fire>();

        //organize hierarchy
        fireObject.gameObject.transform.parent = this.transform;
    }
}
