using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCheck2 : MonoBehaviour
{
    public GameObject scriptObj;
    private DragMiniGame script;

    void Start()
    {
        script = scriptObj.GetComponent<DragMiniGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
            script.touchCount++;
            //script.test3 = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
            script.touchCount++;
            //script.test2 = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            //script.test3 = false;
            script.touchCount--;
            script.timer = 5f;
        }
    }
}
