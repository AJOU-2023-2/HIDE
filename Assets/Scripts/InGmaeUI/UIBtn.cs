using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBtn : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Memo;
    public GameObject Map;

    //Turn on and off the Inventory Panel
    public void InventoryUI()
    {
        if(Inventory.activeSelf == false)
        {
            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
        }
    }

    //Turn on and off the Memo Panel
    public void MemoUI()
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

    //Turn on and off the Map Panel
    public void MapUI()
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
