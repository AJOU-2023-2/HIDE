using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBtn : MonoBehaviour
{
    public GameObject Inventory; //Inventory Panel
    public GameObject Memo; //Memo Panel
    public GameObject Map; //Map Panel
    public GameObject MapBtn; //Map Button

    public bool CheckItem1 = false;
    public bool CheckItem2 = false;
    public TMP_Text ItemName;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Detail1;
    public GameObject Detail2;

    public bool CheckMap = false;
    public GameObject MapCellar; //Cellar Map
    public GameObject Map1st; //1st Map
    public GameObject Map2nd; //2nd Map

    void Update()
    {
        InventorySystem();

        if (CheckMap == true)
        {
            MapBtn.SetActive(true);
        }
    }

    //Turn on and off the Inventory Panel
    public void InventoryUI()
    {
        if (Memo.activeSelf == true || Map.activeSelf == true)  //If Memo or Map is opened,
        {
            return; //Inventory should not be opened
        }
        else
        {
            if (Inventory.activeSelf == false)
            {
                Inventory.SetActive(true);
            }
            else
            {
                Inventory.SetActive(false);
            }
        }
    }

    //Turn on and off the Memo Panel
    public void MemoUI()
    {
        if (Inventory.activeSelf == true || Map.activeSelf == true) //If Inventory or Map is opened,
        {
            return; //Memo should not be opened
        }
        else
        {
            if (Memo.activeSelf == false)
            {
                Memo.SetActive(true);
            }
            else
            {
                Memo.SetActive(false);
            }
        }
    }

    //Turn on and off the Map Panel
    public void MapUI()
    {
        if (Inventory.activeSelf == true || Memo.activeSelf == true) //If Inventory or Memo is opened,
        {
            return; //Map should not be opened
        }
        else
        {
            if (Map.activeSelf == false)
            {
                Map.SetActive(true);
            }
            else
            {
                Map.SetActive(false);
            }
        }
    }

    //Show Inventory's Item Image and Item Name
    void InventorySystem()
    {
        if (CheckItem1 == true)
        {
            CheckItem1 = false;
            Item1.SetActive(true); //Show Item1 Icon
            Detail1.SetActive(true); //Show only Item1's detail
            Detail2.SetActive(false);
            ItemName.text = "Test Key";
        }
        if (CheckItem2 == true)
        {
            CheckItem2 = false;
            Item2.SetActive(true); //Show Item2 Icon
            Detail1.SetActive(false);
            Detail2.SetActive(true); //Show only Item2's detail
            ItemName.text = "Test Key2";
        }
    }

    public void MapCellarBtn()
    {
        MapCellar.SetActive(true); //Show only Cellar Map
        Map1st.SetActive(false);
        Map2nd.SetActive(false);
    }

    public void Map1stBtn()
    {
        MapCellar.SetActive(false);
        Map1st.SetActive(true); //Show only 1st Floor Map
        Map2nd.SetActive(false);
    }

    public void Map2ndBtn()
    {
        MapCellar.SetActive(false);
        Map1st.SetActive(false);
        Map2nd.SetActive(true); //Show only 2nd Floor Map
    }
}
