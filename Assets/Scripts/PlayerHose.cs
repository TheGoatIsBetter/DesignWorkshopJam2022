//Author: Adam White
//Date created: 10/15/2022
//Date of last change: 10/15/2022
//Purpose: Control the spawning/relocation of the water and potentially the tank valume.

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHose : MonoBehaviour
{
    float waterSpawnCooldown; //The timer to make sure the WATER_PER_SECOND is not exceeded, and so there's less gameobjects that make up the water.
    public GameObject player; //Assign in the inspector.

    //Potential variables that can be used to implement new features or easilly change the script.
    const int WATER_PER_SECOND = 20; //Decides how many water squares will spawn each second.
    const float WATER_POINT_RATIO = 0.03f; //Decides the where the water will end at vs the position of the mouse.
    const float WATER_BODY_OFFSET = 0.8f; //Make it so the water spawns outside the player's body.
    const float MIN_DISTANCE = 2.0f; //How close to the player the water can "touch the ground."
    const float MAX_DISTANCE = 10.0f;
    const float PRECISION = 0.5f; //The max offset a random vector can be in both axis.

    //Tank variables below for the optional implementation.
    public float tank; //The percentage of water left in the tank. It is public so the UI can access it. Range 0 (empty) to 1 (full)
    //bool refilling; //Prevents the hose from consuming water and fills up the tank while true.
    //const float TANK_REFILL_RATE = 0.00084f; //It refils 5% of the tank per second (at 60 fps).
    //const float TANK_DRAIN_RATE = 0.00017f; //It drains 1% of the tank per second (at 60 fps).

    void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }

    void Start()
    {
        tank = 1.0f;
        waterSpawnCooldown = 0;
    }

    void Update()
    {
    }

    //OPTIONAL IMPLEMENTATION: Functions for refilling tank.
    /*void RefillWater()
    {
        tank += TANK_DRAIN_RATE; //NOTE: Not time based because firing water is frame-based.
    }
    void StartRefilling() //Called by collider to start filling the tank.
    {
        refilling = true;
    }
    void StopRefilling() //Called by collider when the player stops filling the tank.
    {
        refilling = false;
    }*/

    public void ShootWater()
    {
        if(waterSpawnCooldown <= 0)
        {
            if (tank > 0)
            {
                //IMPLEMENT LATER: sound effect for continuing to fire the hose
                //if(!refilling) //OPTIONAL IMPLEMENTATION: Drains the tank while firing.
                //  tank -= TANK_DRAIN_RATE; //NOTE: Since firing a water rectangle is frame-based and not time-based, water drains only every time the player fires, not affected by time.
                SpawnWater();
                waterSpawnCooldown = 1 / (float)WATER_PER_SECOND; //Set the cooldown so when WATER_PER_SECONDs water has spawned, a second has passed (represented as a 1 in time.deltatime).
            }
            else
            {
                //OPTIONAL IMPLEMENTATION: sound effect for an empty tank.
            }

        }
        else
        {
            waterSpawnCooldown -= Time.deltaTime;
        }
        //if(refilling) //OPTIONAL IMPLEMENTATION: Refills the tank.
        //  RefillWater();
    }

    void SpawnWater()
    {
        Vector2 waterDestination = GetWaterDestination(); //Get where the water is going to go based on the mouse
        //Make sure the water doesn't immediatly despawn if the cursor is inside the player.
        if(waterDestination.magnitude <= MIN_DISTANCE)
        {
            waterDestination.Normalize();
            waterDestination *= MIN_DISTANCE;
        }
        else if (waterDestination.magnitude >= MAX_DISTANCE)
        {
            waterDestination.Normalize();
            waterDestination *= MAX_DISTANCE;
        }

        //Get the object pool and a waterTile from it.
        GameObject waterInstance = WaterPoolManager.waterPool.Dequeue();
        waterInstance.SetActive(true);
        waterInstance.transform.position = (Vector3)(waterDestination.normalized * WATER_BODY_OFFSET) + player.transform.position;
        waterInstance.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(waterDestination.y / waterDestination.x));

        //Passes the new data to the instance each time it is relocated.
        WaterMovement waterMovement = waterInstance.GetComponent<WaterMovement>();
        waterMovement.endPoint = waterDestination;
        waterMovement.startPoint = transform.position;

        WaterPoolManager.waterPool.Enqueue(waterInstance); //This makes sure that the object stays in the pool, error without this.
    }

    Vector2 GetWaterDestination()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2); //Gets the screen coordinates relative to the camera
        Debug.Log(screenPosition);
        Vector2 worldPosition = screenPosition * WATER_POINT_RATIO;
        Vector2 randomOffset = new Vector2(Random.Range(-PRECISION, PRECISION), Random.Range(-PRECISION, PRECISION));
        worldPosition += randomOffset;
        return (worldPosition);
    }
}
