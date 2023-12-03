using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EscapeTimer : MonoBehaviour
{
    public GameObject EscapeTimerUI;
    public TMP_Text timer;
    private float count = 16;

    void Update()
    {
        if(EscapeTimerUI.activeSelf == true)
        {
            if(count < 0)
            {
                //gameover
                Debug.Log("gameover");
                return;
            }
            else if(count >= 10)
            {
                count -= Time.deltaTime;
                timer.text = "00 : " + (int)count;
            }
            else if (count < 10)
            {
                count -= Time.deltaTime;
                timer.text = "00 : 0" + (int)count;
            }
        }
    }
}
