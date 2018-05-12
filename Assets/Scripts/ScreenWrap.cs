//Created by: Chris Deere
//Date: 18/03/18
//Description: Moves ship to other end of the screen after going out of bounds
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenWrap : MonoBehaviour
{
    //Bools for if the ship is of the edge
    bool OutOfBoundsTop;
    bool OutOfBoundsRight;
    bool OutOfBoundsBottom;
    bool OutOfBoundsLeft;

    void Start()
    {
      
    }

    void Update()
    {
        //Position variable
        var newPosition = transform.position;

        //Sets bools to true if the ship goes of the edge
        if (transform.position.z > 100)
        {
            OutOfBoundsTop = true;
        }

        if ( transform.position.z < -100)
        {
            OutOfBoundsBottom = true;
        }

        if (transform.position.x > 100)
        {
            OutOfBoundsRight = true;
        }

        if (transform.position.x < -100)
        {
            OutOfBoundsLeft = true;
        }

        //Moves ship to the otherside of the screen
        if (OutOfBoundsTop)
        {
            newPosition.z = -newPosition.z + 2;
            transform.position = newPosition;
            OutOfBoundsTop = false;
        }

        if (OutOfBoundsBottom)
        {
            newPosition.z = -newPosition.z - 2;
            transform.position = newPosition;
            OutOfBoundsBottom = false;
        }


        if (OutOfBoundsRight)
        {
            newPosition.x = -newPosition.x + 2;
            transform.position = newPosition;
            OutOfBoundsRight = false;
        }

        if (OutOfBoundsLeft)
        {
            newPosition.x = -newPosition.x - 2;
            transform.position = newPosition;
            OutOfBoundsLeft = false;
        }

    }
}
