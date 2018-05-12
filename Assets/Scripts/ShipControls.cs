//Created by: Simon Moth
//Date: 29/10/17
//Description: Basic controls for the ship and basic cameras
//also includes some triggerable audio
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipControls : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;

    private GameObject Boat;

    public AudioClip Cannon;
    AudioSource cannonAudioSource;
    public bool AllowMove = true;
    public bool Collided = false;

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;

        cannonAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        Sound sound = GetComponent<Sound>();

        Boat = this.gameObject.transform.gameObject;

        Boat.GetComponent<BoxCollider>();

        if (AllowMove)
        {
            if (!Collided)
            {
                //sets the crew to the number in the inventory script
                float iCrewMembers = this.gameObject.GetComponent<ShipInventory>().GetCrew();
                iCrewMembers = iCrewMembers / 600;

                //sets the max size
                if (sound.loudness > 0.5f)
                {
                    sound.loudness = 0.5f;
                }

                //moves the ship based on the loudness of the mic and the crew
                float xTranslate = (1f * Time.deltaTime) + (sound.loudness * 8) + iCrewMembers;
                transform.Translate(xTranslate, 0f, 0f);
            }
        }


        if (AllowMove || Collided)
        {
            //if the ship is able to move then rotate the ship's axis
            float yAngle = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
            transform.Rotate(0f, yAngle, 0f);
            

            //swap the camera
            if (Input.GetKeyDown(KeyCode.C))
            {
                cam1.enabled = !cam1.enabled;
                cam2.enabled = !cam2.enabled;
            }

            //plays cannon sound
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //cannonAudioSource.PlayOneShot(Cannon, 0.7F);
                //cannonAudioSource.Play();
            }
        }
    }
}


