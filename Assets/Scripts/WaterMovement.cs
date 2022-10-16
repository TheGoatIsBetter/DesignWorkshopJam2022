//Author: Adam White
//Date created: 10/15/2022
//Date of last change: 10/15/2022
//Purpose: Move each tile of water forward and make it grow and shrink to give the illusion of height.

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public Vector2 endPoint; //The distance and direction the water will be traveling in, relative to the water itself (not worldspace)
    public Vector2 startPoint; //The starting point of the water.

    //Potential variables that can be used to implement new features or easilly change the script.
    float speed; //The water might slow down at the middle for the illusion, so I included a variable for speed if we want to implement later.
    const float AVE_SPEED = 5.0f;
    const float X_SCALE = 0.5f; //Modifies how wide the water will grow. This value + WIDTH is the apex.
    const float Y_SCALE = 0.5f; //Modifies how long the water will grow. This value + HEIGHT is the apex.
    const float WIDTH = 0.4f; //The base width of the water.
    const float HEIGHT = 0.3f; //The base height of the water.

    void Start()
    {
        speed = 1.5f * AVE_SPEED;
    }

    void Update()
    {
        //Move water
        transform.position += (Vector3)endPoint.normalized * (speed * Time.deltaTime);

        float scale = GetParabolaFormula(GetPercentDistance(startPoint, endPoint, transform.position));
        if (scale >= 0) //If the water goes out of bounds of the parabola, it collided with the "floor"
            transform.localScale = new Vector3(X_SCALE * scale + WIDTH, Y_SCALE * scale + HEIGHT, 0); //The range for the scale is 1 to 1 + X/Y_Scale.
        else
            WaterCollidedWithFloor();

        //OPTIONAL IMPLEMENTATION: The water overlap will work so water at the apex will cover the other water.
    }

    //Calculates where on the parabula the water is.
    float GetPercentDistance(Vector2 start, Vector2 end, Vector2 current)
    {
        Vector2 currentLocal = current - start;
        //Since they are on the same line, they share a ratio, so we only need to return the ratio for one component.
        //Cannot divide by zero, so if the vector is perfect horizontal or vertical, return the other component.
        //Also, if the water hasn't moved yet, then it will return 0%.
        if (end.x >= 0.001 || end.x <= -0.001)
            return (currentLocal.x / end.x);
        else if (end.y >= 0.001 || end.y <= -0.001)
            return (currentLocal.y / end.y);
        else
        {
            return (0);
        }
    }

    //The formula for the rate at which the water grows/shrinks.
    float GetParabolaFormula(float percent)
    {
        return(4 * percent * (1 - percent)); //Returns a range of 0-1, provided a range of 0-1 (percentage of distance to target).
    }

    //Function controlls what happens when the water hits the "floor."
    void WaterCollidedWithFloor()
    {
        //IMPLEMENT LATER: particle effect
        gameObject.SetActive(false); //DO NOT DESTROY! It will mess with the pool.
    }
}
