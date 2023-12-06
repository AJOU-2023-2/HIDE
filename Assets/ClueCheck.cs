using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCheck : MonoBehaviour
{
    public GameObject Timer;
    private GameObject obj;
    private int count = 0;

    private bool a = true;

    void Start()
    {
        obj = GameObject.Find("Exit");
    }
    // Update is called once per frame
    void Update()
    {
        if (count == 2 && a = true)
        {
            Timer.SetActive(true);
            obj.GetComponent<Exit>().check = true;
            a = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Knife")
        {
            count++;
        }
        else if (collision.tag == "Diary")
        {
            count++;
        }
    }
}
