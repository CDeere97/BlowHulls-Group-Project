//Created by: Simon Moth
//Date: 18/01/18
//Edited by: Chris Deere
//Description: Generates a countdown timer from 5 minutes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public Text counterText;

    public int seconds, minutes;

    public int iFrames;
    public int iMinutes;

    public bool GameEnd = false;

    private GameObject ShipParent;

    private GameObject GC;
    private GameControl GCScript;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled - KT
        Application.targetFrameRate = 30; //Lock the frame rate to 30 - KT
    }

    // Use this for initialization
    void Start () {
        counterText = GetComponent<Text>() as Text;
        //StartCoroutine(StartCountdown());

        iFrames = 5400; //30 = 1 second, 5400 = 3 minutes
	}

    public IEnumerator StartCountdown(int maxSeconds = 10)
    {
        seconds = maxSeconds;
        while (seconds >= 0)
        {
            //Debug.Log(seconds + " seconds");
            counterText.text = "Time: " + seconds.ToString();
            yield return new WaitForSeconds(1.0f);
            seconds--;
        }
        counterText.text = "Game Over";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameEnd)
        {
            iFrames--;
        }
        
        while (iFrames > 1800)
        {
            iFrames -= 1800;
            iMinutes += 1;
        }

        if (iFrames == 0 && iMinutes != 0)
        {
            iMinutes -= 1;
            ShipParent = GameObject.FindGameObjectWithTag("Player1");
            ShipInventory ShipScript = ShipParent.GetComponent<ShipInventory>();
            int iFood = ShipScript.GetFood();
            int iCrew = ShipScript.GetCrew();
            if (iFood == 0)
            {
                Debug.Log("Half of crew: " + iCrew / 2);
                if ((iCrew / 2) < 1)
                {
                    iCrew--;
                }
                else
                {
                    iCrew = (iCrew / 2);
                }
                ShipScript.SetCrew(iCrew);
            }
            else
            {
                iFood -= iCrew;
                ShipParent.GetComponent<ShipInventory>().SetFood(iFood);
            }
            iFrames += 1800;
        }
        else if (iFrames == 600 || iFrames == 1200)
        {
            ShipParent = GameObject.FindGameObjectWithTag("Player1");
            ShipInventory ShipScript = ShipParent.GetComponent<ShipInventory>();
            int iFood = ShipScript.GetFood();
            int iCrew = ShipScript.GetCrew();

            if (iFood < iCrew)
            {
                iCrew -= (iCrew - iFood);

            }
            if (iFood == 0)
            {
                Debug.Log("Half of crew: " + iCrew / 2);
                if ((iCrew / 2) < 1)
                {
                    iCrew--;
                }
                else
                {
                    iCrew = (iCrew / 2);
                }
                ShipScript.SetCrew(iCrew);
            }
            else
            {
                iFood -= iCrew;
                ShipScript.SetFood(iFood);
            }
            
        }
        counterText.text = iMinutes + " : ";
        if (iFrames < 300)
        {
            counterText.text += "0" + iFrames / 30;
        }
        else
        {
            counterText.text += iFrames / 30;
        }
        if (iFrames <= 0 && iMinutes <= 0)
        {
            GC = GameObject.FindGameObjectWithTag("GameControl");
            GCScript = GC.GetComponent<GameControl>();
            GCScript.SetGold(GameObject.FindGameObjectWithTag("Player1").GetComponent<ShipInventory>().GetGold());
            GCScript.SetEnding(2);
            SceneManager.LoadScene("Ending");
            GameEnd = true;
        }
        /*while (seconds > 0 && minutes > 0)
        {
            minutes = (float)(0 - (Time.time / 60f));
            seconds = (float)(10 - (Time.time % 60f));
            counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }*/
        

        //if (minutes <= 0)
        //{
        //    if (seconds <= 1)
        //    {
        //        Application.Quit();
        //        //Debug.Log("Exit");
        //    }
        //}
	}
}
