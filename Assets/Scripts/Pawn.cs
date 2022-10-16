using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Controller controller;
    protected Mover mover;

    [Header("Speeds")]
    public float maxMoveSpeed;
    public float baseMoveSpeed;
    public float moveSpeed;
    public float maxTurnSpeed;
    public float baseTurnSpeed;
    public float turnSpeed;

    void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
