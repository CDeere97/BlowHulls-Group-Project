//Created by: Kieran Townley
//Date: 22/01/18
//Description: This is used to spawn envionmental obstructions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnvironmentalObstruction : MonoBehaviour
{

    int iMinFoodDamage = 0;
    int iMaxFoodDamage = 0;
    int iMinGoldDamage = 0;
    int iMaxGoldDamage = 0;
    int iMinCrewDamage = 0;
    int iMaxCrewDamage = 0;

    int iRandomSpawning = 0;
    int iRandomScale = 0;

    Material m_Material;

    // Use this for initialization
    void Start()
    {
        //m_Material = GetComponent<Renderer>().material;

        int iTypeOfObstruction = Random.Range(0, 1);
        //0 = Rain
        //1 = Wind
        //2 = Storm
        //3 = Tornado
        if (iTypeOfObstruction == 0)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            iMinFoodDamage = 0;
            iMaxFoodDamage = 1;
            iMinGoldDamage = 0;
            iMaxGoldDamage = 1;
            iMinCrewDamage = 0;
            iMaxCrewDamage = 0;
            //m_Material.color = Color.blue;
        }
        else if (iTypeOfObstruction == 1)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            iMinFoodDamage = 0;
            iMaxFoodDamage = 2;
            iMinGoldDamage = 0;
            iMaxGoldDamage = 2;
            iMinCrewDamage = 0;
            iMaxCrewDamage = 1;
            //m_Material.color = Color.gray;
        }
        else if (iTypeOfObstruction == 2)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            iMinFoodDamage = 0;
            iMaxFoodDamage = 4;
            iMinGoldDamage = 0;
            iMaxGoldDamage = 4;
            iMinCrewDamage = 0;
            iMaxCrewDamage = 2;
            //m_Material.color = Color.yellow;
        }
        else if (iTypeOfObstruction == 3)
        {
            iMinFoodDamage = 2;
            iMaxFoodDamage = 8;
            iMinGoldDamage = 2;
            iMaxGoldDamage = 8;
            iMinCrewDamage = 1;
            iMaxCrewDamage = 4;
            m_Material.color = Color.red;
        }
        iRandomScale = Random.Range(1, 4);
        //transform.localScale = new Vector3(2 * iRandomScale, 3, 2 * iRandomScale);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        iRandomSpawning = Random.Range(0, 10000);
        //Debug.Log(iRandomSpawning);
        if (iRandomSpawning == 50)
        {
            //this.gameObject.SetActive(false);
        }
        iRandomScale = Random.Range(1, 4);
        if (iRandomSpawning == 60)
        {
            //transform.localScale = new Vector3(2 * iRandomScale, 3, 2 * iRandomScale);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if collided with a player then apply the obstructions negatives to resources to the players inventory
        if (other.gameObject.CompareTag("Player1"))
        {
            GameObject Player1 = GameObject.Find("Player1");
            ShipInventory InventoryScript = Player1.GetComponent<ShipInventory>();
            int iGold = InventoryScript.GetGold();
            int iFood = InventoryScript.GetFood();
            int iCrew = InventoryScript.GetCrew();
            iGold -= Random.Range(iMinGoldDamage, iMaxGoldDamage);
            //if there isnt enough gold, then set it to 0
            if (iGold < 0)
            {
                iGold = 0;
            }
            InventoryScript.SetGold(iGold);
            iFood -= Random.Range(iMinFoodDamage, iMaxFoodDamage);
            //if there isnt enough food, then set it to 0
            if (iFood < 0)
            {
                iFood = 0;
            }
            InventoryScript.SetFood(iFood);
            iCrew -= Random.Range(iMinCrewDamage, iMaxCrewDamage);
            //if there isnt enough crew, then set it to 0
            if (iCrew < 0)
            {
                iCrew = 0;
            }
            InventoryScript.SetCrew(iCrew);
        }
    }
}
