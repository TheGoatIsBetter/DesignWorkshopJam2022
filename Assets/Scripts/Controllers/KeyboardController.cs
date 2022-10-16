using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPawn))]
public class KeyboardController : PlayerController
{
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode moveForward;
    [SerializeField] private KeyCode moveBackward;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode fire;
    [SerializeField] private KeyCode pause;

    [Header("External References")]
    [SerializeField] private PlayerHose hose;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void ProcessInputs()
    {
        //These functions just tell PlayerPawn what direction to move.
        if (Input.GetKey(moveForward))
        {
            playerPawn.MoveForward(pawn.moveSpeed);
        }
        if (Input.GetKey(moveBackward))
        {
            playerPawn.MoveForward(-pawn.moveSpeed);
        }
        if (Input.GetKey(moveRight))
        {
            playerPawn.MoveRight(pawn.moveSpeed);
        }
        if (Input.GetKey(moveLeft))
        {
            playerPawn.MoveRight(-pawn.moveSpeed);
        }
        playerPawn.MovePlayer(); //This function is what actually moves the player
        if (Input.GetKey(fire))
        {
            hose.ShootWater();
        }
        if (Input.GetKey(pause))
        {
            GameManager.instance.PauseGame();
        }
    }
}
