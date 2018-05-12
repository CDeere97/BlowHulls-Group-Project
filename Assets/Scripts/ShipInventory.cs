//Created by: Kieran Townley
//Date: 18/01/18
//Description: This is used to store the how many supplies the player has
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipInventory : MonoBehaviour {

    [SerializeField]
    private int iGold;

    [SerializeField]
    private int iFood;

    [SerializeField]
    private int iCrew;

    private Text _statusText;
    private Text _deathText;
    private Text _levelText;

    public Transform LocalPlayer;

    public Camera PhoneCamera;
    public Canvas PhoneCanvas;

    public static Canvas PortCanvas;

    private bool ExitPort = false;
    private bool PlayerInPort = false;

    [SerializeField]
    private GameObject PortObj;

    private Port PortScript;

    public GameObject PortCanvasObject;

    private GameObject GC;
    private GameControl GCScript;

    private Text GoldLeftText;
    private Text FoodLeftText;
    private Text FoodCostText;
    private Text HireCostText;

    // Use this for initialization
    void Start () {
        iGold = 0;
        iFood = 10;
        iCrew = 5;

        GameObject textGameObject = GameObject.FindWithTag("GoldText");
        _statusText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("FoodText");
        _deathText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("CrewText");
        _levelText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("GoldLeft");
        GoldLeftText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("FoodLeft");
        FoodLeftText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("FoodCost");
        FoodCostText = textGameObject.GetComponent<Text>();

        textGameObject = GameObject.FindWithTag("HireCost");
        HireCostText = textGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        _statusText.text = iGold.ToString();
        _deathText.text = iFood.ToString();
        _levelText.text = iCrew.ToString();

        //set the text to red if you're out
        if (iFood == 0)
        {
            _deathText.color = Color.red;
        }
        else
        {
            _deathText.color = Color.white;
        }

        if (iCrew <= 0)
        {
            GC = GameObject.FindGameObjectWithTag("GameControl");
            GCScript = GC.GetComponent<GameControl>();
            GCScript.SetGold(iGold);
            GCScript.SetEnding(1);
            SceneManager.LoadScene("Ending");
        }
    }

    //getters and setters
    public int GetGold()
    {
        return iGold;
    }

    public int GetFood()
    {
        return iFood;
    }

    public int GetCrew()
    {
        return iCrew;
    }

    public void SetGold(int a_iGold)
    {
        iGold = a_iGold;
    }

    public void SetFood(int a_iFood)
    {
        iFood = a_iFood;
    }

    public void SetCrew(int a_iCrew)
    {
        iCrew = a_iCrew;
    }

    //updating the invetory when the player collides with the port, adds set gold when docking
    public void CollidedWithPort(GameObject a_ObjPort)
    {
        Debug.Log("Collision With: " + a_ObjPort.gameObject.name);
        ExitPort = false;
        PlayerInPort = true;
        this.gameObject.GetComponent<ShipControls>().AllowMove = false;
        PortObj = a_ObjPort.gameObject;
        PortScript = PortObj.GetComponent<Port>();
        iGold += PortScript.GetAmountOfGoldCollected();
        iFood += PortScript.GetAmountOfFoodCollected();

        GoldLeftText.text = PortScript.GetAmountOfGold().ToString();
        FoodLeftText.text = PortScript.GetAmountOfFood().ToString();
        FoodCostText.text = PortScript.GetFoodCost().ToString();
        HireCostText.text = PortScript.GetCrewCost().ToString();
        Debug.Log("Food: " + PortScript.GetAmountOfFood() + " / " + "Gold: " + PortScript.GetAmountOfGold());
    }

    //function to buy supplies
    public void BuySupplies()
    {
        Debug.Log("Buy supplies");
        int FoodCost = PortScript.GetFoodCost();
        int FoodInPort = PortScript.GetAmountOfFood();

        //decrease the food in the port and increase the players food. decreases gold by the food cost
        if ((iGold - FoodCost) >= 0 && FoodInPort > 0)
        {
            iGold = iGold - FoodCost;
            iFood++;
            FoodInPort--;
            PortScript.SetAmountOfFood(FoodInPort);
            int GoldInPort = PortScript.GetAmountOfGold();
            GoldInPort += FoodCost;
            PortScript.SetAmountOfGold(GoldInPort);
            GoldLeftText.text = PortScript.GetAmountOfGold().ToString();
            FoodLeftText.text = PortScript.GetAmountOfFood().ToString();
            FoodCostText.text = PortScript.GetFoodCost().ToString();
            HireCostText.text = PortScript.GetCrewCost().ToString();
        }
    }
    //hiring crew for the crew cost in gold
    public void HireCrew()
    {
        Debug.Log("Hire crew");
        int CrewCost = PortScript.GetCrewCost();

        if ((iGold - CrewCost) >= 0)
        {
            iGold = iGold - CrewCost;
            iCrew++;
            int GoldInPort = PortScript.GetAmountOfGold();
            GoldInPort += CrewCost;
            PortScript.SetAmountOfGold(GoldInPort);
            GoldLeftText.text = PortScript.GetAmountOfGold().ToString();
            FoodLeftText.text = PortScript.GetAmountOfFood().ToString();
            FoodCostText.text = PortScript.GetFoodCost().ToString();
            HireCostText.text = PortScript.GetCrewCost().ToString();
        }
    }

    //function for exiting the port
    public void SetPortExit()
    {
        Debug.Log("Set Sail");
        ExitPort = false;
        ExitPort = true;
        PlayerInPort = false;
        this.gameObject.GetComponent<ShipControls>().AllowMove = true;
        this.gameObject.transform.Rotate(Vector3.up, 180);
        PortScript.PlayerInPort = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GC = GameObject.FindGameObjectWithTag("GameControl");
        GCScript = GC.GetComponent<GameControl>();
        GCScript.SetGold(GameObject.FindGameObjectWithTag("Player1").GetComponent<ShipInventory>().GetGold());
        GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>().SetEnding(0);
        SceneManager.LoadScene("Ending");
    }
}
