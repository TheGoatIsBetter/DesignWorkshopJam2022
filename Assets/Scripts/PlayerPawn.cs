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
        direction.y = Mathf.Sign(moveSpeed); //moveSpeed's sign determines the direction.
    }
    public void MoveRight(float moveSpeed)
    {
        direction.x = Mathf.Sign(moveSpeed); //moveSpeed's sign determines the direction.
    }

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    Vector2 direction = Vector2.zero;
    const float COLLISION_OFFSET = 0.1f; //How much of a gap there is between colliders
    public ContactFilter2D collisionFilter; //Assign in the inspector so the collision ignores water.

    public void MovePlayer()
    {
        if (direction != Vector2.zero)
        {
            //Detects any collisions that would occur in the space it would move to.
            int count = rigidbodyComponent.Cast(
                direction,
                collisionFilter,
                castCollision,
                moveSpeed * Time.fixedDeltaTime + COLLISION_OFFSET
            );
            if (count == 0) //If there is no collisions, then count == 0.
            {
                Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime; //Use fixedDeltaTime since this is happening in FixedUpdate

                rigidbodyComponent.MovePosition(rigidbodyComponent.position + moveVector); //move rigidbody position at a rate of speed by time since last frame
            }
            else
            {
                //If both inputs don't work, then perhaps the player can slide across the wall on the x-axis.
                count = rigidbodyComponent.Cast(
                    new Vector2(direction.x, 0),
                    collisionFilter,
                    castCollision,
                    moveSpeed * Time.fixedDeltaTime + COLLISION_OFFSET
                );
                if(count == 0)
                {
                    Vector2 moveVector = new Vector2(direction.x * moveSpeed * Time.fixedDeltaTime, 0);

                    rigidbodyComponent.MovePosition(rigidbodyComponent.position + moveVector);
                }
                else
                {
                    //If the player can't slide along the wal on the x-axis, perhaps the y-axis.
                    count = rigidbodyComponent.Cast(
                        new Vector2(0, direction.y),
                        collisionFilter,
                        castCollision,
                        moveSpeed * Time.fixedDeltaTime + COLLISION_OFFSET
                    );
                    if (count == 0)
                    {
                        Vector2 moveVector = new Vector2(0, direction.y * moveSpeed * Time.fixedDeltaTime);

                        rigidbodyComponent.MovePosition(rigidbodyComponent.position + moveVector);
                    }
                }
            }
        }
        direction = Vector2.zero; //Reset input
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
