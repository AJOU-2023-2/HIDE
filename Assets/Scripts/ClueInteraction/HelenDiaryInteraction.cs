using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelenDiaryInteraction : MonoBehaviour
{
    public BookController bookController;
    public MiaDiaryInteraction mia;

    [SerializeField]
    Button nextButton;
    [SerializeField]
    Button previousButton;
    [SerializeField]
    Image bookImage;
    [SerializeField]
    Sprite bookTexture;

    public GameObject[] pages;

    public int currentPage;

    public TMP_Text DiaryText;
    public GameObject DialogPanel;

    public GameObject HelenDiary;

    public GameObject NextBtn;
    public GameObject PreviousBtn;

    bool Helen = false;

    void Start()
    {
        UpdatePage();

        nextButton.onClick.AddListener(NextPage);
        previousButton.onClick.AddListener(PreviousPage);

        NextBtn.SetActive(false);
        PreviousBtn.SetActive(false);
    }

    void NextPage()
    {
        bookController.NextPage();
        currentPage = Mathf.Min(++currentPage, pages.Length - 1);
        StartCoroutine(UpdatePageDelayed());
    }

    void PreviousPage()
    {
        bookController.PreviousPage();
        currentPage = Mathf.Max(--currentPage, 0);
        StartCoroutine(UpdatePageDelayed());
    }

    IEnumerator UpdatePageDelayed()
    {
        yield return new WaitForEndOfFrame();
        UpdatePage();
    }

    public void UpdatePage()
    {
        Array.ForEach(pages, c => { c.SetActive(false); });
        pages[currentPage].SetActive(true);
        Debug.Log("helen : " + currentPage); //test
        nextButton.gameObject.SetActive(currentPage < pages.Length - 1);
        previousButton.gameObject.SetActive(currentPage > 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogPanel.SetActive(true);
            DiaryText.text = "헬렌의 일기장이다. 읽어볼까?";
            Helen = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HelenDiary.SetActive(false);
            NextBtn.SetActive(false);
            PreviousBtn.SetActive(false);
            Helen = false;
        }
    }

    public void ShowHelen()
    {
        if (Helen)
        {
            currentPage = 0;   //if player activate the diary, player can see fist page of the diary
            mia.currentPage = 0;
            UpdatePage();
            HelenDiary.SetActive(true);
            NextBtn.SetActive(true);
            DialogPanel.SetActive(false);
        }
    }

    public void NoBtn()
    {
        DialogPanel.SetActive(false);
    }
}
