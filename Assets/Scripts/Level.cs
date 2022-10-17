using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelGenerator levelGenerator;

    //store the level after created
    public Room[,] grid;

    //store spawn locations
    public List<Vector3> playerSpawns;

    // Start is called before the first frame update
    void Start()
    {
    }


    //clear everything from the level
    public void clearLevel()
    {
        if(grid != null)
        {
            GameManager.instance.fireManager.fireSpawnerList.Clear();

            //playerSpawns.Clear();

            GameManager.instance.playerSpawnPoints.Clear();
            foreach (Room room in grid)
            {
                Destroy(room);
            }

            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }


        }

    }

}
