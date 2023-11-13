using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exit : MonoBehaviour
{
    public int exitcheck = 0; //다음에 적절한 상황에서 UI가 바뀌도록 bool 변수 만들 것! 우선 이거 예비로 사용
    public GameObject panel;
    public TMP_Text tmp;
    public GameObject YesButton;
    public GameObject NoButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(true);
            if(exitcheck == 0) tmp.text = "아직 나갈 때가 아닌 것 같다.";
            if(exitcheck == 1) tmp.text = "문이 잠겨있습니다.";
            if(exitcheck == 2)
            {
                tmp.text = "아이템을 사용하시겠습니까?";
                YesButton.SetActive(true);
                NoButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(false);
        }
    }

    public void YesBtn()
    {
        Time.timeScale = 1;
        //엔딩 씬으로 전환
    }

    public void NoBtn()
    {
        panel.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
    }
}
