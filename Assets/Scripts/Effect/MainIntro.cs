using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainIntro : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject backgroundPanel;
    public GameObject background;
    public GameObject text;
    Image image;

    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;

    void Awake()
    {
        StartCoroutine(StartText());
    }

    IEnumerator StartText()
    {
        yield return new WaitForSeconds(0.5f);
        text.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
        backgroundPanel.SetActive(false);
        fadePanel.SetActive(true);
        background.SetActive(true);
        StartCoroutine(FadeInStart());
    }

    IEnumerator FadeInStart()
    {
        image = fadePanel.GetComponent<Image>();
        float fadeCount = 1.0f;
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0,0,0,fadeCount);
        }
        fadePanel.SetActive(false);
        yield return new WaitForSeconds(1f);
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.SetActive(true);
    }
}
