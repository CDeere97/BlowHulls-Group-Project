//Created by: Kieran Townley
//Date: 08/02/18
//Description: Menu script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if there is already a game controller then destroy it
        if (GameObject.Find("Game Control"))
        {
            Destroy(GameObject.Find("GameControl"));
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            try
            {
                GameObject.Find("GameControl").name = "Game Control";
            }
            catch
            {

            }
            GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>().TestLeaderboard();
        }
    }

    //load the game scene when the start button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("Instructions");
    }

    //load the leaderboard
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
