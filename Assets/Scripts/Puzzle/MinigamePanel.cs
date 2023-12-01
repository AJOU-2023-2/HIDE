using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePanel : MonoBehaviour
{
    public GameObject panel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            panel.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            panel.SetActive(false);
    }
}
