using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider slVol;
    float fSliderBarTime;
    void Start()
    {
       slVol = GetComponent<Slider>();
    }
 
 
    void Update()
    {
        if (slVol.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
