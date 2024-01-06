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
        // if (other.gameObject.CompareTag("Block"))
        //     script.OnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            //script.OnTriggerExit2D(other);
        }
    }
}
