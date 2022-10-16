using UnityEngine;

public class Room : MonoBehaviour
{
    public int[] position;
    public GameObject doorNorth;
    public GameObject doorSouth;
    public GameObject doorWest;
    public GameObject doorEast;
    public GameObject fireSpawner;

    public bool[] doors = {true, true, true, true};

    public GameObject[] westObjects;
    public GameObject[] southObjects;

    void Start()
    {
        doorNorth.SetActive(!doors[0]);
        doorEast.SetActive(!doors[1]);
        doorSouth.SetActive(!doors[2]);
        doorWest.SetActive(!doors[3]);
    }
}
