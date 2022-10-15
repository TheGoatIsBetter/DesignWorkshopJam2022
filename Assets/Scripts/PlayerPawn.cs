using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerPawn : Pawn, Mover
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveForward(float moveSpeed)
    {
        Debug.Log('d');
    }

    public void Turn(float turnSpeed)
    {
        Debug.Log('f');
    }

    //public void MoveForward(float moveSpeed)
    //{
        //move
    //    if(mover != null)
    //    {
    //        mover.MoveForward(moveSpeed);
    //    }
    //}

   
}
