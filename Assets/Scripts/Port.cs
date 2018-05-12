//Created by: Simon Moth
//Date: 9/02/18
//Description: Script for the port stuff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Port : MonoBehaviour {

    [SerializeField]
    private int iAmountOfGold;

    [SerializeField]
    private int iAmountOfFood;

    private int iTimer;

    [SerializeField]
    public int FoodCost;

    [SerializeField]
    private int CrewCost;

    public bool PlayerInPort = false;
    private Canvas PortCanvas;
    private GameObject PortCanvasObject;


    public bool ExitPort = false;

    public GameObject Player1;

    public Image ImageOverlay;

    public Text GoldLeftText;
    public Text FoodLeftText;
    public Text FoodCostText;
    public Text HireCostText;

	// Use this for initialization
	void Start () {
        //setup the maximum amount of food and gold at each port
        iAmountOfGold = Random.Range(100, 150);
        iAmountOfFood = Random.Range(30, 80);
       
        PortCanvasObject = GameObject.FindGameObjectWithTag("PortCanvas");
        PortCanvas = PortCanvasObject.GetComponent<Canvas>();

        //costs for the food and crew at ports
        FoodCost = Random.Range(1, 3);
        CrewCost = Random.Range(20, 30);

        PortCanvas.enabled = false;
    }

// Update is called once per frame
void Update () {
        
    }
    //exit function for the port UI button
    public void SetPortExit(bool a_exit)
    {
        ExitPort = true;
    }
    //getters and setters for the gold and food
    public int GetAmountOfGold()
    {
        return iAmountOfGold;
    }

    public void SetAmountOfGold(int a_iGold)
    {
        iAmountOfGold = a_iGold;
    }

    public int GetAmountOfFood()
    {
        return iAmountOfFood;
    }

    public void SetAmountOfFood(int a_iFood)
    {
        iAmountOfFood = a_iFood;
    }

    //get the cost of food amd crew
    public int GetFoodCost()
    {
        return FoodCost;
    }

    public int GetCrewCost()
    {
        return CrewCost;
    }
    //function for the collection of food
    public int GetAmountOfFoodCollected()
    {
        int FoodCollected = 0;
        //if there is still food then set it to the amount of food minus the taken amount
        if (iAmountOfFood > 4)
        {
            FoodCollected = Random.Range(2, 4);
        }
        else
        {
            FoodCollected = iAmountOfFood;
        }
        iAmountOfFood -= FoodCollected;
        return FoodCollected;
    }
    //collects gold for the player when they enter port
    public int GetAmountOfGoldCollected()
    {
        int GoldCollected = 0;
        if (iAmountOfGold >= 50)
        {
            GoldCollected = Random.Range(50, (iAmountOfGold - 3));
        }
        else if (iAmountOfGold >= 10)
        {
            GoldCollected = Random.Range(1, iAmountOfGold);
        }
        iAmountOfGold -= GoldCollected;
        return GoldCollected;
    }
}
