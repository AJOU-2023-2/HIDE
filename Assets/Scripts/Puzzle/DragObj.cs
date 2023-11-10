using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour
{   
    private float distance = 3.0f;
    private Vector3 pos;
    public bool dragCheck;

    void Start()
    {
        pos = this.transform.position;
        dragCheck = true;
    }

    void OnMouseDrag()
    { 
        if(dragCheck)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    public void MoveObj()
    {
        this.transform.position = pos;
    }
}
