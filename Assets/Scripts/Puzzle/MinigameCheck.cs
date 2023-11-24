using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCheck : MonoBehaviour
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            script.touchCount--;
            script.timer = 5f;
        }
    }
}
