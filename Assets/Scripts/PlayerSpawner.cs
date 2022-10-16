using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.playerSpawnPoints.Add(this.gameObject);
    }

    public void SpawnPlayer()
    {
        //spawn object
        spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

        //organize hierarchy
        spawnedObject.gameObject.transform.parent = this.transform;

        //reset health
        spawnedObject.GetComponent<Health>().currentHealth = spawnedObject.GetComponent<Health>().maxHealth;

        //kickstart the crackling fire
        FireCrackler fireCrackler = spawnedObject.GetComponentInChildren(typeof(FireCrackler), false) as FireCrackler;
        fireCrackler.fireCrackle.Play();
    }

   
}
