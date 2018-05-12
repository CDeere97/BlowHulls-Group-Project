// Created by: Chris Deere
// Date: 18/01/18
// Description: Enable gyroscope controls for android
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Outputs acceleration input to log
        float temp = Input.acceleration.x;
        //Debug.Log(temp);
        //transform.Translate((temp / 2), 0, 0);
        if (this.gameObject.GetComponent<ShipControls>().AllowMove)
        {
            transform.Rotate(0, temp, 0);
        }
	}
}
