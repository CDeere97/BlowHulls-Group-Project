//Created by: Chris Deere
//Edited by: Simon Moth
//Date: 19/11/17
//Description: Gets the sound input from the microphone
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource _audio;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        while(!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        loudness = GetAveragedVolume()* sensitivity;
       /* if (loudness > 2)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector2(this.GetComponent<Rigidbody>().velocity.x, 4);
        } */
	}

    //Makes the volume average out so that it doesnt speratically move
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
