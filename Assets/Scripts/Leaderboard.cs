using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

    private int[] Scores;
    private string[] Names;

    private GameObject GC;
    private GameControl GCScript;

    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    public Text Text5;
    public Text Text6;
    public Text Text7;
    public Text Text8;
    public Text Text9;
    public Text Text10;

    public Text[] Texts = new Text[10];

    public InputField PlayerName;
    public Text EnteredName;

    public void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || PlayerName.text.Length > 0)
        {
            if ((PlayerName.text != null) && (EnteredName != null))
            {
                NameConfirmed();
            }
        }
    }

    // Use this for initialization
    void Start () {
        GC = GameObject.FindGameObjectWithTag("GameControl");
        GCScript = GC.GetComponent<GameControl>();
        if (GCScript.GetGold() != 0)
        {
            for (int a = 0; a < 10; a++)
            {
                Texts[a].CrossFadeAlpha(0.0f, 0.0f, false);
            }
        }
        else
        {
            GameObject.Find("InputField").SetActive(false);
            NameConfirmed();
        }
	}

    public void NameConfirmed()
    {
        GC = GameObject.FindGameObjectWithTag("GameControl");
        GCScript = GC.GetComponent<GameControl>();
        if (GCScript.GetGold() != 0)
        {
            string Name = GameObject.Find("InputField").transform.GetChild(2).GetComponent<Text>().text;
            Debug.Log(Name);
            GCScript.SetName(Name);
            GCScript.PutScoreOnLeaderboard();
            GameObject.Find("InputField").SetActive(false);
        }   
        GCScript.Load();
        Scores = GCScript.GetScores();
        Names = GCScript.GetNames();

        for (int a = 0; a < 10; a++)
        {
            Debug.Log(Scores[a]);
            Texts[a].CrossFadeAlpha(1.0f, 0.0f, false);
            Texts[a].text = a + ". " + Scores[a] + " by " + Names[a];
        }

        GCScript.SetGold(0);
    }

    private void OnEnable()
    {
        Names = new string[10];
        Scores = new int[10];

        for (int a = 0; a < 10; a++)
        {
            Names[a] = null;
            Scores[a] = 0;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Return) || PlayerName.text.Length > 0)
        {
            if ((PlayerName.text != null) && (EnteredName != null))
            {
                NameConfirmed();
            }
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("Menu");
    }
}
