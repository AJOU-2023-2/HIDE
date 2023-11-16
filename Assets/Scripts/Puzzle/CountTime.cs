using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTime : MonoBehaviour
{
    public GameObject controlObject;

    private DragMiniGame controlScript;
    private bool clear;

    void Start()
    {
        controlScript = controlObject.GetComponent<DragMiniGame>();
    }

    void Update()
    {
        if(controlScript.touchCount > 0 && controlScript.timerCheck && !clear)
        {
            this.GetComponent<TextMeshProUGUI>().text = "남은 시간 : " + Mathf.Round(controlScript.timer);
            if(controlScript.timer <= 0) clear = true;
        }
        else controlScript.timer = 0;
    }
}
