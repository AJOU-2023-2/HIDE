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
    public GameObject game;
    public GameObject player;
    public ModalWindowManager myModalWindow;
    public GameObject ui;
    public GameObject background;

    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;

    //맵 이동 관련 오브젝트
    public GameObject change;
    public GameObject noChange;


    //독백패널 오브젝트
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;
    public GameObject exit;

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
            //obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj.GetComponent<DragObj>().dragCheck = true;
        }
    }

    IEnumerator Fail()
    {
        countText.SetActive(true);
        countText.GetComponent<TextMeshProUGUI>().text = "Please reposition.";
        yield return new WaitForSeconds(1f);
        countText.SetActive(false);
    }

    IEnumerator Clear()
    {
        myModalWindow.ModalWindowIn();
        yield return new WaitForSeconds(1f);
        myModalWindow.ModalWindowOut();
        player.SetActive(true);
        ui.SetActive(true);
        StartCoroutine(ShowPanel());
    }

    IEnumerator ShowPanel()
    {
        background.SetActive(false);
        //player.GetComponent<Move>().enabled = false;
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.GetComponent<TypingEffect>()._dialog[0] = "I must get out of this mansion quickly.";
        characterText.GetComponent<TMP_Text>().text = characterText.GetComponent<TypingEffect>()._dialog[0];
        characterText.SetActive(true);
        ui.SetActive(true);
        change.SetActive(true);
        noChange.SetActive(false);
        game.SetActive(false);

        clue1.SetActive(true);
        clue2.SetActive(true);
        clue3.SetActive(true);
        clue4.SetActive(true);

    }
}
