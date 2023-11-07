using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragPuzzle : MonoBehaviour
{
    public int touchCount = 0;
    public float timer = 0f;
    private bool gameClear = false;
    private bool timerCheck = false;
    private GameObject[] objs;

    public GameObject countText;
    public GameObject startButton;
    public GameObject restartButton;

    void Update()
    {
        if (touchCount > 0 && timerCheck)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                gameClear = true;
            }
        }

        if (gameClear)
        {
            Debug.Log("게임 클리어!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            touchCount++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            touchCount--;
            timer = 0;
        }
    }

    public void StartCount()
    {
        if(touchCount > 0)
        {
            startButton.SetActive(false);
            restartButton.SetActive(true);
            countText.SetActive(true);
            timerCheck = true;
        }
        else {
            startButton.SetActive(false);
            restartButton.SetActive(true);
            StartCoroutine(fail());
            timerCheck = false;
        }
    }

    public void ReStart()
    {
        timer = 0;
        countText.SetActive(false);
        restartButton.SetActive(false);
        startButton.SetActive(true);
        objs = GameObject.FindGameObjectsWithTag("Block");
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<DragObj>().MoveObj();
        }
    }

    IEnumerator fail()
    {
        countText.SetActive(true);
        countText.GetComponent<TextMeshProUGUI>().text = " 다시 배치하십시오. ";
        yield return new WaitForSeconds(1f);
        countText.SetActive(false);
    }
}
