using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject playerobj;
    public GameObject playerEffect;
    private GameObject myInstance;

    public UIBtn uIBtn;
    private bool check;

    private float distance;

    public GameObject exit;

    void Update()
    {
        distance = Vector2.Distance(playerobj.transform.position, transform.position);
        if(distance < 3.0f)
        {
            if(playerobj.transform.Find("Effect(Clone)") == null)
            {
                myInstance = Instantiate(playerEffect, playerobj.transform);
                myInstance.SetActive(true);
            }
        }
        else
        {
            Destroy(myInstance);
        }
    }

    private void Effect()
    {
        if(check == true)
            playerEffect.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && this.gameObject.tag == "Map")
        {
            if(myInstance != null) Destroy(myInstance);
            uIBtn.CheckMap = true;
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
        }
        if(collision.tag == "Player" && this.gameObject.tag == "BundleKey")
        {
            if(myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
            uIBtn.Item1.SetActive(true); //Show BundleKey Icon
        }
        if(collision.tag == "Player" && this.gameObject.tag == "CusKey")
        {
            if(myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
            uIBtn.Item2.SetActive(true); //Show CusKey Icon
        }
        if (collision.tag == "Player" && this.gameObject.tag == "LucyKey")
        {
            if (myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
            uIBtn.Item3.SetActive(true); //Show LucyKey Icon
        }
        if (collision.tag == "Player" && this.gameObject.tag == "EntKey")
        {
            if (myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            exit.GetComponent<Exit>().exitcheck = 2;
            playerEffect.SetActive(false);
            uIBtn.Item4.SetActive(true); //Show EntKey Icon
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Knife")
        {
            if (myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
            uIBtn.Item5.SetActive(true); //Show Knife Icon
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Diary")
        {
            if (myInstance != null) Destroy(myInstance);
            Destroy(this.gameObject);
            playerEffect.SetActive(false);
            uIBtn.Item6.SetActive(true); //Show Diary Icon
        }
    }
}
