//Created by: Kieran Townley
//Date: 22/01/18
//Description: used for saving the highscore and other data between scenes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private int iGold = 0;

    private string[] Names;
    private int[] Scores;

    private string Name;

    private bool KeyboardOnScreen = false;

    public int ScorePosition = 0;

    private int HighScore;

    private int Ending; //0 Crash, 1 Crew, 2 Timer

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnEnable()
    {
        Names = new string[10];
        Scores = new int[10];

        for (int a = 0; a < 10; a++)
        {
            Names[a] = null;
            Scores[a] = 0;
        }
    }

    public void TestLeaderboard()
    {
    }

    public void Save()
    {
        //creates a binary formatter
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.Names = Names;
        data.Scores = Scores;
        data.HighScore = HighScore;

        bf.Serialize(file, data);
        Debug.Log("File created");
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            Names = data.Names;
            Scores = data.Scores;
            HighScore = data.HighScore;
            Debug.Log("File loaded");
        }
        else
        {
            Save();
            Load();
        }
    }

    public void ClearFile()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log("File deleted");
        }
    }

    public void PutScoreOnLeaderboard()
    {
        Load();
        if (iGold <= Scores[9])
        {
            Debug.Log("Early out");
            return;
        }
        else
        {
            Scores[9] = 0;
        }

        for (int a = 8; a > -1; a--)
        {
            if (iGold > Scores[a])
            {
                int number = a;
                number++;
                Scores[number] = Scores[a];
                Names[number] = Names[a];
            }
            else
            {
                Debug.Log("Set score");
                int number = a;
                number++;
                Debug.Log("Number: " + number);
                Scores[number] = iGold;
                Names[number] = Name;
                Save();
                return;
            }
        }

        if (iGold > Scores[0])
        {
            Debug.Log("Set score");
            Scores[0] = iGold;
            Names[0] = Name;
            Save();
        }
        
    }

    public void SetGold(int a_iGold)
    {
        iGold = a_iGold;
    }

    public int GetGold()
    {
        return iGold;
    }

    public string[] GetNames()
    {
        return Names;
    }

    public int[] GetScores()
    {
        return Scores;
    }

    public void SetName(string a_sName)
    {
        Name = a_sName;
    }

    public int GetHighScore()
    {
        return HighScore;
    }

    public void CheckHighScore()
    {
        if (iGold > HighScore)
        {
            HighScore = iGold;
        }
    }

    public int GetEnding()
    {
        return Ending;
    }

    public void SetEnding(int a_Ending)
    {
        Ending = a_Ending;
    }
}

[Serializable]
class PlayerData
{
    public string[] Names;
    public int[] Scores;

    public PlayerData()
    {
        Names = new string[10];
        Scores = new int[10];

        for (int a = 0; a < 10; a++)
        {
            Names[a] = null;
            Scores[a] = 0;
        }
    }

    public int HighScore;
}

