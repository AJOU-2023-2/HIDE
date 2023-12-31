using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenClick : MonoBehaviour, IPointerClickHandler
{
    public UIBtn uIBtn;

    public GameObject InvenItem1;
    public GameObject InvenItem2;
    public GameObject InvenItem3;
    public GameObject InvenItem4;
    public GameObject InvenItem5;
    public GameObject InvenItem6;

    public void OnPointerClick(PointerEventData eventData) //When click the item in the inventory, activate the item's bool variable
    {
        if (eventData.pointerEnter == InvenItem1)
        {
            uIBtn.CheckItem1 = true;
        } else if (eventData.pointerEnter == InvenItem2)
        {
            uIBtn.CheckItem2 = true;
        }
        else if (eventData.pointerEnter == InvenItem3)
        {
            uIBtn.CheckItem3 = true;
        }
        else if (eventData.pointerEnter == InvenItem4)
        {
            uIBtn.CheckItem4 = true;
        }
        else if (eventData.pointerEnter == InvenItem5)
        {
            uIBtn.CheckItem5 = true;
        }
        else if (eventData.pointerEnter == InvenItem6)
        {
            uIBtn.CheckItem6 = true;
        }

    }
}
