using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCheck_pg2 : MonoBehaviour
{
    public GameObject clue5;
    private int count = 0;

    void Update()
    {
        if(count == 5)
        {
            clue5.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hDiary1")
        {
            count++;
            Debug.Log("touch");
        }
        else if (collision.tag == "hDiary2")
        {
            count++;
            Debug.Log("touch");
        }
        else if (collision.tag == "mMemo")
        {
            count++;
            Debug.Log("touch");
        }
        else if (collision.tag == "oMemo2")
        {
            count++;
            Debug.Log("touch");
        }
        else if (collision.tag == "hDiary__2")
        {
            count++;
            Debug.Log("touch");
        }
    }
}
