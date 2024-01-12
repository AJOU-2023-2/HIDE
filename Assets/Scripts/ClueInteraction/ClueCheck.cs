using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCheck : MonoBehaviour
{
    public GameObject Timer;
    public GameObject clue;

    private GameObject obj;
    private int count = 0;
    private int count2 = 0;

    private bool a = true;
    private bool b = true;

    public GameObject clueCheck;
    public GameObject clueCheck2;
    public GameObject clueCheck3;
    public GameObject clueCheck4;
    public GameObject clueCheck5;

    void Start()
    {
        obj = GameObject.Find("Exit");
    }
    
    void Update()
    {
        if (count == 2 && a == true)
        {
            Timer.SetActive(true);
            obj.GetComponent<Exit>().check = true;
            a = false;
        }
        else if (count2 == 5 && b == true)
        {
            clue.SetActive(true);
            b = false;
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
        else if (collision.tag == "hDiary1")
        {
            count2++;
            clueCheck.SetActive(true);
        }
        else if (collision.tag == "hDiary2")
        {
            count2++;
            clueCheck2.SetActive(true);
        }
        else if (collision.tag == "mMemo")
        {
            count2++;
            clueCheck3.SetActive(true);
        }
        else if (collision.tag == "oMemo2")
        {
            count2++;
            clueCheck4.SetActive(true);
        }
        else if (collision.tag == "hDiary__2")
        {
            count2++;
            clueCheck5.SetActive(true);
        }
    }
}
