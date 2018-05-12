//Created by: Simon Moth
//Date: 9/02/18
//Description: ship collisions, positions, and rotation changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBody : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //setting the ships rotation and position to that of the parent
        this.gameObject.transform.position = this.gameObject.GetComponentInParent<Transform>().position;
        this.gameObject.transform.rotation = this.gameObject.GetComponentInParent<Transform>().rotation;
        this.gameObject.transform.TransformPoint(this.gameObject.GetComponentInParent<Transform>().position);
    }

    public void OnTriggerEnter(Collider other)
    {
        //if collision with the port is detected eneable the port menu 
        if (other.gameObject.tag == "Port")
        {
            this.gameObject.GetComponentInParent<ShipInventory>().CollidedWithPort(other.gameObject);
            GameObject.FindGameObjectWithTag("PortCanvas").GetComponent<Canvas>().enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //disables the menu when you leave the port
        if (other.gameObject.tag == "Port")
        {
            GameObject.FindGameObjectWithTag("PortCanvas").GetComponent<Canvas>().enabled = false;
        }
    }
    //detects if there is a collision and sets a bool to true
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            this.gameObject.GetComponentInParent<ShipControls>().Collided = true;
        }
    }
    //when there isnt a collisiona disable the bool
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            this.gameObject.GetComponentInParent<ShipControls>().Collided = false;
        }
    }
}
