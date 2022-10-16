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
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProcessInputs()
    {
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
        if (Input.GetKey(fire))
        {
            hose.ShootWater();
        }
    }
}
