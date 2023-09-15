using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject manualBar;

    //Fade Effect
    public GameObject panel;
    Image image;

    public void GameStart()
    {
        panel.SetActive(true);
        image = panel.GetComponent<Image>();
        StartCoroutine(StartFadeCoroutine());
    }

    IEnumerator StartFadeCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0,0,0,fadeCount);
        }
        SceneManager.LoadScene("Main");
    }

    public void GameQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    //Game panel
    public void ManualBar()
    {
        if(manualBar.activeSelf == true)
        {
            manualBar.SetActive(false);
        }else {
            manualBar.SetActive(true);
        }
    }
}
