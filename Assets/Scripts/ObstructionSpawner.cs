//Created by: Kieran Townley
//Date: 13/02/18
//Description: spawner for environmental factors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class ObstructionSpawner : MonoBehaviour {
    int iRandomSpawner;
    public GameObject Obstruction1;
    public GameObject Obstruction2;
    public GameObject Obstruction3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //sets active to each of the obstructions 
        iRandomSpawner = Random.Range(0, 500);
        if (iRandomSpawner == 2)
        {
            Obstruction1.SetActive(true);
        }
        else if (iRandomSpawner == 4)
        {
            Obstruction2.SetActive(true);
        }
        else if (iRandomSpawner == 6)
        {
            Obstruction3.SetActive(true);
        }
	}
}
