using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TomDiaryInteraction1 : MonoBehaviour
{
    public BookController bookController;
    public HelenDiaryInteraction1 helen1;
    public MiaDiaryInteraction mia;
    public LucyDiaryInteraction lucy;
    public DemianDiaryInteraction demian;
    public HelenDiaryInteraction2 helen2;
    public TomDiaryInteraction2 tom2;

    [SerializeField]
    Button nextButton;
    [SerializeField]
    Button previousButton;
    [SerializeField]
    Button closeButton;
    [SerializeField]
    Image bookImage;
    [SerializeField]
    Sprite bookTexture;

    public GameObject[] pages;

    public int currentPage;

    public TMP_Text DiaryText;
    public GameObject DialogPanel;

    public GameObject TomDiary;

    public GameObject NextBtn;
    public GameObject PreviousBtn;
    public GameObject Closebtn;

    bool Tom = false;

    void Start()
    {
        UpdatePage();

        nextButton.onClick.AddListener(NextPage);
        previousButton.onClick.AddListener(PreviousPage);
        closeButton.onClick.AddListener(Close);

        NextBtn.SetActive(false);
        PreviousBtn.SetActive(false);
        Closebtn.SetActive(false);
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

    void Close()
    {
        TomDiary.SetActive(false);
        NextBtn.SetActive(false);
        PreviousBtn.SetActive(false);
        Closebtn.SetActive(false);
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
        nextButton.gameObject.SetActive(currentPage < pages.Length - 1);
        previousButton.gameObject.SetActive(currentPage > 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogPanel.SetActive(true);
            DiaryText.text = "It is Tom's diary. Should I read it?";
            Tom = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogPanel.SetActive(false);
            TomDiary.SetActive(false);
            NextBtn.SetActive(false);
            PreviousBtn.SetActive(false);
            Closebtn.SetActive(false);
            Tom = false;
        }
    }

    public void ShowTom1()
    {
        if (Tom)
        {
            currentPage = 0;   //if player activate the diary, player can see fist page of the diary
            mia.currentPage = 0;
            helen1.currentPage = 0;
            lucy.currentPage = 0;
            demian.currentPage = 0;
            helen2.currentPage = 0;
            tom2.currentPage = 0;
            UpdatePage();
            TomDiary.SetActive(true);
            NextBtn.SetActive(true);
            Closebtn.SetActive(true);
            DialogPanel.SetActive(false);
        }
    }

    public void NoBtn()
    {
        DialogPanel.SetActive(false);
    }
}
