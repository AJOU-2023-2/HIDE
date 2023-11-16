using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiaDiaryInteraction : MonoBehaviour
{
    public BookController bookController;
    public HelenDiaryInteraction1 helen1;
    public TomDiaryInteraction1 tom1;
    public LucyDiaryInteraction lucy;
    public DemianDiaryInteraction demian;
    public HelenDiaryInteraction2 helen2;
    public TomDiaryInteraction2 tom2;

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

    public GameObject MiaDiary;

    public GameObject NextBtn;
    public GameObject PreviousBtn;

    bool Mia = false;

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
        nextButton.gameObject.SetActive(currentPage < pages.Length - 1);
        previousButton.gameObject.SetActive(currentPage > 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogPanel.SetActive(true);
            DiaryText.text = "It is Mia's diary. Should I read it?";
            Mia = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MiaDiary.SetActive(false);
            NextBtn.SetActive(false);
            PreviousBtn.SetActive(false);
            Mia = false;
        }
    }

    public void ShowMia()
    {
        if (Mia)
        {
            currentPage = 0;   //if player activate the diary, player can see fist page of the diary
            helen1.currentPage = 0;
            tom1.currentPage = 0;
            lucy.currentPage = 0;
            demian.currentPage = 0;
            helen2.currentPage = 0;
            tom2.currentPage = 0;
            UpdatePage();
            MiaDiary.SetActive(true);
            NextBtn.SetActive(true);
            DialogPanel.SetActive(false);
        }
    }

    public void NoBtn()
    {
        DialogPanel.SetActive(false);
    }
}
