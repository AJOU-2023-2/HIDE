using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    public BookController bookController;
    
    [SerializeField]
    Button nextButton;
    [SerializeField]
    Button previousButton;
    [SerializeField]
    Image bookImage;
    [SerializeField]
    Sprite bookTexture;
    [SerializeField]
    Sprite notepadTexture;

    public GameObject[] pages;

    public int currentPage;
    View currentView;


    public enum View
    {
        Book,
        Notepad
    }

    void Start()
    {
        Debug.Log("start"); //test
        UpdatePage();

        nextButton.onClick.AddListener(NextPage);
        previousButton.onClick.AddListener(PreviousPage);
    }

    public void SetBook(bool value)
    {
        SetView(value ? View.Book : View.Notepad);
    }

    void SetView(View value)
    {
        if (currentView == value) return;

        currentView = value;
        bookImage.sprite = currentView == View.Book ? bookTexture : notepadTexture;
    }

    void NextPage()
    {
        Debug.Log("this is next page"); //test
        bookController.NextPage();
        currentPage = Mathf.Min(++currentPage, pages.Length - 1);
        StartCoroutine(UpdatePageDelayed());
    }

    void PreviousPage()
    {
        Debug.Log("this is previous page"); //test
        bookController.PreviousPage();
        currentPage = Mathf.Max(--currentPage, 0);
        StartCoroutine(UpdatePageDelayed());
    }
    
    IEnumerator UpdatePageDelayed()
    {
        Debug.Log("this is update delay"); //test
        yield return new WaitForEndOfFrame();
        UpdatePage();
    }
    
    public void UpdatePage()
    {
        Array.ForEach(pages, c => { c.SetActive(false);});
        pages[currentPage].SetActive(true);
        Debug.Log(currentPage); //test
        nextButton.gameObject.SetActive(currentPage < pages.Length - 1);
        previousButton.gameObject.SetActive(currentPage > 0);
    }
}
