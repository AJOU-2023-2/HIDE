using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClueInteraction : MonoBehaviour
{
    public GameObject playerobj;

    public GameObject Num1;
    public GameObject TomMemo;
    public GameObject meMemo;
    public GameObject kMemo;
    public GameObject oMemo;
    public GameObject kNote;
    public GameObject kNote1;
    public GameObject hDiary1;
    public GameObject hDiary2;
    public GameObject mMemo;
    public GameObject oMemo2;
    public GameObject Num2;

    //독백패널 오브젝트
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;
    public GameObject player;
    public GameObject exit;

    [SerializeField]
    Button closeButton;
    public GameObject Closebtn;

    public GameObject key;

    void Start()
    {
        closeButton.onClick.AddListener(Close);
    }

    void Close()
    {
        if(this.gameObject.tag == "Num1")
        {
            Num1.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "TomMemo")
        {
            TomMemo.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "meMemo")
        {
            meMemo.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "kMemo")
        {
            kMemo.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "oMemo")
        {
            oMemo.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "kNote")
        {
            kNote.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "kNote1")
        {
            kNote1.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "hDiary1")
        {
            hDiary1.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "hDiary2")
        {
            hDiary2.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "mMemo")
        {
            mMemo.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "oMemo2")
        {
            oMemo2.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "Num2")
        {
            Num2.gameObject.SetActive(false);
        }
        Closebtn.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.gameObject.tag == "Num1")
        {
            Num1.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "TomMemo")
        {
            TomMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "meMemo")
        {
            meMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kMemo")
        {
            kMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo")
        {
            oMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote")
        {
            kNote.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote1")
        {
            kNote1.SetActive(true);
            Closebtn.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary1")
        {
            hDiary1.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary2")
        {
            hDiary2.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "mMemo")
        {
            mMemo.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo2")
        {
            oMemo2.SetActive(true);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Num2")
        {
            Num2.SetActive(true);
        }
        Closebtn.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.gameObject.tag == "Num1")
        {
            Num1.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "TomMemo")
        {
            TomMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "meMemo")
        {
            meMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kMemo")
        {
            kMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo")
        {
            oMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote")
        {
            kNote.SetActive(false);

            //페이즈1에서는 독백 뜨게, 페이즈2에서는 그냥 루시 키 활성화
            if (SceneManager.GetActiveScene().buildIndex == 3)
                StartCoroutine(ShowPanel());
            else
                key.SetActive(true);

        }
        if (collision.tag == "Player" && this.gameObject.tag == "kNote1")
        {
            kNote1.SetActive(false);
            Closebtn.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary1")
        {
            hDiary1.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "hDiary2")
        {
            hDiary2.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "mMemo")
        {
            mMemo.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "oMemo2")
        {
            oMemo2.SetActive(false);
        }
        if (collision.tag == "Player" && this.gameObject.tag == "Num2")
        {
            Num2.SetActive(false);
        }
        Closebtn.SetActive(false);
    }

    IEnumerator ShowPanel()
    {
        exit.GetComponent<Exit>().exitcheck = 1;
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.SetActive(true);
        characterText.GetComponent<TypingEffect>()._dialog[0] = "It seems Kyle has finished his investigation up to this point...";
        characterText.GetComponent<TypingEffect>()._dialog[1] = "First, I should go to my car parked outside the mansion to report the contents of my investigation so far.";
    }
}
