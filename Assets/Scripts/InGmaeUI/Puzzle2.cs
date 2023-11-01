using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle2 : MonoBehaviour, IPointerClickHandler
{
    public GameObject Piece1;
    public GameObject Piece2;
    public GameObject Piece3;
    public GameObject Piece4;
    public GameObject Piece5;
    public GameObject Piece6;
    public GameObject Piece7;
    public GameObject Piece8;
    public GameObject Piece9;
    public GameObject Piece10;
    public GameObject Piece11;
    public GameObject Piece12;
    public GameObject Piece13;
    public GameObject Piece14;
    public GameObject Piece15;
    public GameObject Piece16;

    public bool open = false; //door open state

    public void Update()
    {
        if ((Piece1.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece1.transform.rotation == Quaternion.Euler(0, 0, 360)) 
            && (Piece2.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece2.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece3.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece3.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece4.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece4.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece5.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece5.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece6.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece6.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece7.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece7.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece8.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece8.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece9.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece9.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece10.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece10.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece11.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece11.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece12.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece12.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece13.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece13.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece14.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece14.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece15.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece15.transform.rotation == Quaternion.Euler(0, 0, 360))
            && (Piece16.transform.rotation == Quaternion.Euler(0, 0, 0) || Piece16.transform.rotation == Quaternion.Euler(0, 0, 360)))
        {
            Debug.Log("complete");
            open = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData) //When click the puzzle piece, rotate it
    {
        if (eventData.pointerEnter == Piece1)
        {
            Piece1.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece2)
        {
            Piece2.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece3)
        {
            Piece3.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece4)
        {
            Piece4.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece5)
        {
            Piece5.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece6)
        {
            Piece6.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece7)
        {
            Piece7.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece8)
        {
            Piece8.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece9)
        {
            Piece9.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece10)
        {
            Piece10.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece11)
        {
            Piece11.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece12)
        {
            Piece12.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece13)
        {
            Piece13.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece14)
        {
            Piece14.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece15)
        {
            Piece15.transform.Rotate(0, 0, -90f);
        }
        else if (eventData.pointerEnter == Piece16)
        {
            Piece16.transform.Rotate(0, 0, -90f);
        }
    }
}
