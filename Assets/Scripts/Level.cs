using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //store the level after created
    public Room[,] grid;

    //store spawn locations
    public List<Vector3> playerSpawns;

    public LevelGenerator levelGen;

    // Start is called before the first frame update
    void Start()
    {
    }

    //clear everything from the level
    public void clearLevel()
    {
        if(grid != null)
        {
            playerSpawns.Clear();
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
