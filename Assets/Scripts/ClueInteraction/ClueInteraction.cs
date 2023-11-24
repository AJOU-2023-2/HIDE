using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInteraction : MonoBehaviour
{
    public GameObject playerobj;

    public GameObject Num1;
    public GameObject TomMemo;
    public GameObject meMemo;
    public GameObject kMemo;
    public GameObject oMemo;
    public GameObject kNote;
    public GameObject kNote1;
    public GameObject hDiary1;
    public GameObject hDiary2;
    public GameObject mMemo;
    public GameObject oMemo2;
    public GameObject Num2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.gameObject.tag == "Num1")
        {
            Num1.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "TomMemo")
        {
            TomMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "meMemo")
        {
            meMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kMemo")
        {
            kMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo")
        {
            oMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote")
        {
            kNote.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote1")
        {
            kNote1.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary1")
        {
            hDiary1.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary2")
        {
            hDiary2.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "mMemo")
        {
            mMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo2")
        {
            oMemo2.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Num2")
        {
            Num2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.gameObject.tag == "Num1")
        {
            Num1.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "TomMemo")
        {
            TomMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "meMemo")
        {
            meMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kMemo")
        {
            kMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo")
        {
            oMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote")
        {
            kNote.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote1")
        {
            kNote1.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary1")
        {
            hDiary1.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary2")
        {
            hDiary2.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "mMemo")
        {
            mMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo2")
        {
            oMemo2.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Num2")
        {
            Num2.SetActive(false);
        }
    }
}
