using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public GameObject OptionBtn;
    public GameObject CloseOptionBtn;

    public GameObject WarningPanel;
    public GameObject OptionPanel;

    public void SettingBtn()
    {
        if (OptionBtn.activeSelf == true || CloseOptionBtn.activeSelf == true)  //If Setting is opened,
        {
            OptionBtn.SetActive(false); //Close Setting
            CloseOptionBtn.SetActive(false);
        }
        else
        {
            OptionBtn.SetActive(true); //Open Setting
            CloseOptionBtn.SetActive(true);
        }
    }

    public void CloseUI()
    {
        WarningPanel.SetActive(true);
    }

    public void YesBtn()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void NoBtn()
    {
        WarningPanel.SetActive(false);
    }

    public void OpenOptPanel()
    {
        OptionPanel.SetActive(true);
    }

    public void ExitOptionBtn()
    {
        OptionPanel.SetActive(false);
    }
}
