using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public GameObject OptionBtn;
    public GameObject CloseBtn;

    public void SettingBtn()
    {
        if (OptionBtn.activeSelf == true || CloseBtn.activeSelf == true)  //If Setting is opened,
        {
            OptionBtn.SetActive(false); //Close Setting
            CloseBtn.SetActive(false);
        }
        else
        {
            OptionBtn.SetActive(true); //Open Setting
            CloseBtn.SetActive(true);
        }
    }

    public void CloseUI()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
