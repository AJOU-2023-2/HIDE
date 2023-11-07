using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTime : MonoBehaviour
{
    public GameObject controlObject;

    private DragPuzzle controlScript;

    void Start()
    {
        controlScript = controlObject.GetComponent<DragPuzzle>();
    }

    void Update()
    {
        if(controlScript.touchCount > 0)
            this.GetComponent<TextMeshProUGUI>().text = "남은 시간 : " + controlScript.timer;
    }
}
