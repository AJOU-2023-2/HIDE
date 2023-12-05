using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Exit : MonoBehaviour
{
    public int exitcheck = 0; //다음에 적절한 상황에서 UI가 바뀌도록 bool 변수 만들 것! 우선 이거 예비로 사용
    public GameObject panel;
    public TMP_Text tmp;
    public GameObject YesButton;
    public GameObject NoButton;

    //독백패널 오브젝트
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;
    public GameObject player;
    public GameObject lucyKey;
    public GameObject anim;

    public bool check;  //톰 방에서 증거 모두 수집시 On

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(true);
            if(exitcheck == 0) tmp.text = "I don't think it's time to leave yet..";
            if(exitcheck == 1) tmp.text = "The door is locked.";
            if(exitcheck == 2)
            {
                if(!check)
                {
                    tmp.text = "I'm not going out until I get evidence of this crime";
                }else {
                    tmp.text = "Would you like to use the item?";
                    YesButton.SetActive(true);
                    NoButton.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(false);
            if(exitcheck == 1)  StartCoroutine(ShowPanel());
        }
    }

    IEnumerator ShowPanel()
    {
        //player.GetComponent<Move>().enabled = false;
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.GetComponent<TypingEffect>()._dialog[0] = "Why is the mansion’s door locked? I’m sure it was not locked before…";
        characterText.GetComponent<TMP_Text>().text = characterText.GetComponent<TypingEffect>()._dialog[0];
        characterText.SetActive(true);
        lucyKey.SetActive(true);
    }

    public void YesBtn()
    {
        panel.SetActive(false);
        anim.SetActive(true);
    }

    public void YesBtn2()
    {
        SceneManager.LoadScene("Ending");
    }

    public void NoBtn()
    {
        panel.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
    }
}
