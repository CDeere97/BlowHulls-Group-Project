//Created by: Simon Moth
//Date: 04/11/17
//Description: This is used to store the how many supplies the player has
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTilt : MonoBehaviour {

    public Animator Tilt;

    // Use this for initialization
    void Start () {
        Tilt = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {


        //set up tilt controls for the ship, allowing the ship to tilt left and right when turning
        if (Input.GetKeyDown(KeyCode.A))
        {
            //print("The A key was pressed");
            Tilt.Play("LeftTurnStart");
            transform.Rotate(0f, 20f * Time.deltaTime, 0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //print("The A key was released");
            Tilt.Play("LeftTurnEnd");
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            //print("The D key was pressed");
            Tilt.Play("RightTurnStart");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //print("The D key was released");
            Tilt.Play("RightTurnEnd");
        }
    }
}
