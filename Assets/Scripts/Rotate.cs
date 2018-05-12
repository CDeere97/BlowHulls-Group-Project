using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float yAngle = Input.GetAxis("Horizontal") * 100000 * Time.deltaTime;
        //transform.Rotate(0f, yAngle, 0f);
        transform.Rotate(Vector3.up * Time.deltaTime * 10000f);
    }
}
