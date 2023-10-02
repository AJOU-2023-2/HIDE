using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenClick : MonoBehaviour, IPointerClickHandler
{
    public UIBtn uIBtn;

    public GameObject InvenItem1;
    public GameObject InvenItem2;
    
    public void OnPointerClick(PointerEventData eventData) //When click the item in the inventory, activate the item's bool variable
    {
        if (eventData.pointerEnter == InvenItem1)
        {
            uIBtn.CheckItem1 = true;
        } else if (eventData.pointerEnter == InvenItem2)
        {
            uIBtn.CheckItem2 = true;
        }

    }
}
