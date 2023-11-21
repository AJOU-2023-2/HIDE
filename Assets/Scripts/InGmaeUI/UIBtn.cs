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
    public GameObject PlayerObj;

    public bool CheckItem1 = false;
    public bool CheckItem2 = false;
    public bool CheckItem3 = false;
    public bool CheckItem4 = false;
    public bool CheckItem5 = false;
    public bool CheckItem6 = false;
    public TMP_Text ItemName;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject Detail1;
    public GameObject Detail2;
    public GameObject Detail3;
    public GameObject Detail4;
    public GameObject Detail5;
    public GameObject Detail6;

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
                PlayerObj.SetActive(false);

            }
            else
            {
                Memo.SetActive(false);
                PlayerObj.SetActive(true);
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
            Detail1.SetActive(true); //Show only Item1's detail
            Detail2.SetActive(false);
            Detail3.SetActive(false);
            Detail4.SetActive(false);
            Detail5.SetActive(false);
            Detail6.SetActive(false);
            ItemName.text = "A Bunch of Keys";
        }
        if (CheckItem2 == true)
        {
            CheckItem2 = false;
            Detail1.SetActive(false);
            Detail2.SetActive(true); //Show only Item2's detail
            Detail3.SetActive(false);
            Detail4.SetActive(false);
            Detail5.SetActive(false);
            Detail6.SetActive(false);
            ItemName.text = "Guest Room Key";
        }
        if (CheckItem3 == true)
        {
            CheckItem3 = false;
            Detail1.SetActive(false);
            Detail2.SetActive(false);
            Detail3.SetActive(true); //Show only Item3's detail
            Detail4.SetActive(false);
            Detail5.SetActive(false);
            Detail6.SetActive(false);
            ItemName.text = "Lucy's Room Key";
        }
        if (CheckItem4 == true)
        {
            CheckItem4 = false;
            Detail1.SetActive(false);
            Detail2.SetActive(false);
            Detail3.SetActive(false);
            Detail4.SetActive(true); //Show only Item4's detail
            Detail5.SetActive(false);
            Detail6.SetActive(false);
            ItemName.text = "Entrance Key";
        }
        if (CheckItem5 == true)
        {
            CheckItem5 = false;
            Detail1.SetActive(false);
            Detail2.SetActive(false);
            Detail3.SetActive(false);
            Detail4.SetActive(false);
            Detail5.SetActive(true); //Show only Item5's detail
            Detail6.SetActive(false);
            ItemName.text = "Tom's Knife";
        }
        if (CheckItem6 == true)
        {
            CheckItem6 = false;
            Detail1.SetActive(false);
            Detail2.SetActive(false);
            Detail3.SetActive(false);
            Detail4.SetActive(false);
            Detail5.SetActive(false);
            Detail6.SetActive(true); //Show only Item6's detail
            ItemName.text = "Tom's Diary";
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
