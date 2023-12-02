using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase2Intro : MonoBehaviour
{
    public GameObject player;
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;

    void Awake()
    {
        StartCoroutine(Chatting());
    }

    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(2f);
        textpanel.SetActive(true);
        if(characterImage != null && characterName != null)
        {
            yield return new WaitForSeconds(1f);
            characterImage.SetActive(true);
            yield return new WaitForSeconds(1f);
            characterName.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        characterText.SetActive(true);
    }
}
