using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConnect : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject player;
    public GameObject ui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puzzle.SetActive(true);
        player.SetActive(false);
        ui.SetActive(false);
    }
}
