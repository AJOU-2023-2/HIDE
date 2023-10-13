using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject playerobj;
    public GameObject playerEffect;

    private float distance;


    void Update()
    {
        distance = Vector2.Distance(playerobj.transform.position, transform.position);
        if(distance < 3.0f)
        {
            playerEffect.SetActive(true);
        }else
        {
            playerEffect.SetActive(false);
        }
    }
}
