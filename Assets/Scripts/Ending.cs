// Created by: Kieran Townley
// Date: 30/03/18
// Description: Script for the ending screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    private GameObject GC;
    private GameControl GCScript;

    public Text ScoreText;
    public Text HighScoreText;

    public Image CrewEnding;
    public Image TimerEnding;
    public Image CrashEnding;

    // Use this for initialization
    void Start () {
        // get the highscore from the game controller
        GC = GameObject.FindGameObjectWithTag("GameControl");
        GCScript = GC.GetComponent<GameControl>();
        GCScript.CheckHighScore();
        //displaying the score and gold
        ScoreText.text = "Your score was: " + GCScript.GetGold();
        HighScoreText.text = "Your high score is: " + GCScript.GetHighScore();
        GCScript.SetGold(0);
        //save the game
        GCScript.Save();

        int Ending = GCScript.GetEnding();
        //0 Crash, 1 Crew, 2 Timer

        switch (Ending)
        {
            case 0:
                CrewEnding.CrossFadeAlpha(0f, 0f, false);
                TimerEnding.CrossFadeAlpha(0f, 0f, false);
                CrashEnding.CrossFadeAlpha(1.0f, 0f, false);
                break;

            case 1:
                CrewEnding.CrossFadeAlpha(1.0f, 0f, false);
                TimerEnding.CrossFadeAlpha(0f, 0f, false);
                CrashEnding.CrossFadeAlpha(0f, 0f, false);
                break;

            case 2:
                CrewEnding.CrossFadeAlpha(0f, 0f, false);
                TimerEnding.CrossFadeAlpha(1.0f, 0f, false);
                CrashEnding.CrossFadeAlpha(0f, 0f, false);
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //a simple statement to return the player to the menu
		if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
