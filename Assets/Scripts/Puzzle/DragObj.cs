using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour
{   
    //private float distance = 3.0f;
    private Quaternion rot;

    [SerializeField] private Vector3 pos;
    public bool dragCheck;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        rot = this.transform.rotation;
        pos = this.transform.position;
        dragCheck = true;
    }

    void OnMouseDrag()
    { 
        if(dragCheck)
        {
            float distance = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.z = 0;
            transform.position = objPosition;
        }
    }

    public void MoveObj()
    {
        this.transform.position = pos;
        this.transform.rotation = rot;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }
}
