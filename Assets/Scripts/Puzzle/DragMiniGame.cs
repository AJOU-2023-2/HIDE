using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.Dark; // namespace

public class DragMiniGame : MonoBehaviour
{
    public int touchCount = 0;
    public float timer = 5f;
    private bool gameClear = false;
    public bool timerCheck = false;
    private bool check = true;
    private GameObject[] objs;

    public GameObject countText;
    public GameObject startButton;
    public GameObject restartButton;
    public ModalWindowManager myModalWindow;

    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Block");
        foreach(GameObject obj in objs)
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }

    void Update()
    {
        if(check)
        {
            if (touchCount > 0 && timerCheck)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                    gameClear = true;
            }

            if (gameClear)
            {
                StartCoroutine(Clear());
                check = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
            touchCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            touchCount--;
            timer = 5f;
        }
    }

    public void StartCount()
    {
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
            obj.GetComponent<DragObj>().dragCheck = false;
        }

        if(touchCount > 0)
        {
            timer = 5f;
            startButton.SetActive(false);
            restartButton.SetActive(true);
            countText.SetActive(true);
            timerCheck = true;
        }
        else {
            timer = 5f;
            startButton.SetActive(false);
            restartButton.SetActive(true);
            StartCoroutine(Fail());
            timerCheck = false;
        }
    }

    public void ReStart()
    {
        timer = 5f;
        timerCheck = false;
        countText.SetActive(false);
        restartButton.SetActive(false);
        startButton.SetActive(true);
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<DragObj>().MoveObj();
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj.GetComponent<DragObj>().dragCheck = true;
        }
    }

    IEnumerator Fail()
    {
        countText.SetActive(true);
        countText.GetComponent<TextMeshProUGUI>().text = " 다시 배치하십시오. ";
        yield return new WaitForSeconds(1f);
        countText.SetActive(false);
    }

    IEnumerator Clear()
    {
        myModalWindow.ModalWindowIn();
        yield return new WaitForSeconds(1f);
        myModalWindow.ModalWindowOut();
    }
}
