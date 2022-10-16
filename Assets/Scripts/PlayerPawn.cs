using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerPawn : Pawn, Mover
{
    private Rigidbody2D rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MoveForward(float moveSpeed)
    {
        //move rigidbody position forward at a rate of speed by time since last frame
        rigidbodyComponent.MovePosition(transform.position += (transform.up * (moveSpeed * Time.deltaTime)));
    }

    public void MoveRight(float moveSpeed)
    {
        //move rigidbody position right at a rate of speed by time since last frame
        rigidbodyComponent.MovePosition(transform.position += (transform.right * (moveSpeed * Time.deltaTime)));
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
