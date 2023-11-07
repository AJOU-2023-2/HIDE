using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour
{   
    private float distance = 3.0f;
    private Vector3 pos;

    void Start()
    {
        pos = this.transform.position;
    }

    void OnMouseDrag()
    { 
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    // public float GetHeight()
    // {
    //     return transform.position.y;
    // }

    public void MoveObj()
    {
        this.transform.position = pos;
    }
}
