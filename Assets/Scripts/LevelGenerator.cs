using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //level to perform generation on
    public Level level;

    //list of rooms to choose from
    public List<Room> possibleRooms;

    //map data
    private float roomWidth = 20.0f;
    private float roomHeight = 20.0f;

    public int numberOfRows;
    public int numberOfCols;

    public int randomSeed;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateLevel()
    {
        randomSeed = (int)System.DateTime.Now.Ticks;
        Random.InitState(randomSeed);

        //level to operate on is the gamemanager one
        // level = GameManager.instance.level;

        //clear/reset 2D grid matrix
        level.grid = new Room[numberOfCols, numberOfRows];

        //one row at a time
        for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
        {
            //one col at a time
            for (int currentCol = 0; currentCol < numberOfCols; currentCol++)
            {
                //instantiate random room
                Room newRoom = Instantiate(GetNextRoom()) as Room;

                newRoom.position = new int[] {currentRow, currentCol};
                newRoom.transform.position = new Vector3(currentCol * roomHeight, currentRow * roomWidth, 0.0f);

                //give name
                newRoom.gameObject.name = "Room(" + currentCol + ", " + currentRow + ")";
                //organize hierarchy
                newRoom.gameObject.transform.parent = level.transform;

                //save it to grid
                level.grid[currentCol, currentRow] = newRoom;

                // close correct doors and delete overlapping objects
                if (currentRow == 0)
                {
                    newRoom.doors[2] = false;
                }
                else
                {
                    foreach (GameObject obj in newRoom.southObjects)
                    {
                        Destroy(obj);
                    }
                }
                if (currentRow == numberOfRows - 1)
                {
                    newRoom.doors[0] = false;
                }
                if (currentCol == 0)
                {
                    newRoom.doors[3] = false;
                }
                else
                {
                    foreach (GameObject obj in newRoom.westObjects)
                    {
                        Destroy(obj);
                    }
                }
                if (currentCol == numberOfCols - 1)
                {
                    newRoom.doors[1] = false;
                }
            }
        }

        GameManager.instance.fireManager.SpawnRandomFires();

        
    }

    //get the next room in the sequence based on rules
    Room GetNextRoom()
    {
        //returns random room
        return possibleRooms[Random.Range(0, possibleRooms.Count)];
    }
}
