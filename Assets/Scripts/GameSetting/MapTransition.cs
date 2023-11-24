using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapTransition : MonoBehaviour
{
    private CameraController cam;

    public GameObject player;
    private Move moveScript;

    public Vector2 newMinCameraBoundary;
    public Vector2 newMaxCameraBoundary;

    [SerializeField] Vector2 playerPosOffset;
    [SerializeField] Transform exitPos;

    //방 이름 체크 변수
    public GameObject roomUI;
    public TextMeshProUGUI roomTextUI;
    public string roomName;
    public bool uiCheck;

    //방 이동 제어
    public string roomCheck;
    public UIBtn UIBtn;

    //UI 변수
    public GameObject mapChangeUI;
    public TextMeshProUGUI textUI;
    public GameObject yesButtonUI;
    public GameObject NoButtonUI;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
        moveScript = player.GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(roomName == "First Floor" || roomName == "Second Floor" || roomName == "Cellar")
            {
                mapChangeUI.SetActive(true);
                textUI.text = "Do you want to move?";
                yesButtonUI.SetActive(true);
                NoButtonUI.SetActive(true);
                yesButtonUI.GetComponent<Button>().onClick.AddListener(YesBtn);
                NoButtonUI.GetComponent<Button>().onClick.AddListener(NoBtn);
                Time.timeScale = 0;
            }else if(roomCheck == "열쇠꾸러미" || roomCheck == "빈방" || roomCheck == "딸방" || roomCheck == "손님방")
            {
                if(roomCheck == "열쇠꾸러미" && UIBtn.Item1.activeSelf == true)
                {
                    mapChangeUI.SetActive(true);
                    textUI.text = "Do you want to use 'A bunch of keys'?";
                    yesButtonUI.SetActive(true);
                    NoButtonUI.SetActive(true);
                    yesButtonUI.GetComponent<Button>().onClick.AddListener(KeyUseBtn);
                    NoButtonUI.GetComponent<Button>().onClick.AddListener(KeyNotUseBtn);
                }else if(roomCheck == "손님방" && UIBtn.Item2.activeSelf == true)
                {
                    mapChangeUI.SetActive(true);
                    textUI.text = "Do you want to use 'Guest room key'?";
                    yesButtonUI.SetActive(true);
                    NoButtonUI.SetActive(true);
                    yesButtonUI.GetComponent<Button>().onClick.AddListener(KeyUseBtn);
                    NoButtonUI.GetComponent<Button>().onClick.AddListener(KeyNotUseBtn);

                }else if(roomCheck == "딸방" && UIBtn.Item3.activeSelf == true)
                {
                    mapChangeUI.SetActive(true);
                    textUI.text = "Do you want to use 'Lucy's room key'?";
                    yesButtonUI.SetActive(true);
                    NoButtonUI.SetActive(true);
                    yesButtonUI.GetComponent<Button>().onClick.AddListener(KeyUseBtn);
                    NoButtonUI.GetComponent<Button>().onClick.AddListener(KeyNotUseBtn);

                }else{
                    mapChangeUI.SetActive(true);
                    textUI.text = "The door is locked.";
                }
            }else{
                if(uiCheck == true)
                    StartCoroutine(StartFadeCoroutine());
                cam.minCameraBoundary = newMinCameraBoundary;
                cam.maxCameraBoundary = newMaxCameraBoundary;

                player.transform.position = exitPos.position + (Vector3)playerPosOffset;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(roomCheck == "열쇠꾸러미" || roomCheck == "빈방" || roomCheck == "딸방" || roomCheck == "딸방" || roomCheck == "손님방")
            {
                mapChangeUI.SetActive(false);
            }
        }
    }

    IEnumerator StartFadeCoroutine()
    {
        roomTextUI.text = roomName;
        roomUI.SetActive(true);

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            roomUI.GetComponent<Image>().color = new Color(1,1,1,fadeCount);
            roomTextUI.color = new Color(1,1,1,fadeCount);
        }

        yield return new WaitForSeconds(0.3f);

        fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            roomUI.GetComponent<Image>().color = new Color(1,1,1,-fadeCount);
            roomTextUI.color = new Color(1,1,1,-fadeCount);
        }
        roomUI.SetActive(false);
    }

    //키 아이템 사용 할 때 쓰이는 함수
    private void KeyUseBtn()
    {
        roomCheck = "";
        mapChangeUI.SetActive(false);
        yesButtonUI.GetComponent<Button>().onClick.RemoveListener(YesBtn);
        NoButtonUI.GetComponent<Button>().onClick.RemoveListener(NoBtn);
        yesButtonUI.SetActive(false);
        NoButtonUI.SetActive(false);
        if(uiCheck == true)
            StartCoroutine(StartFadeCoroutine());
        cam.minCameraBoundary = newMinCameraBoundary;
        cam.maxCameraBoundary = newMaxCameraBoundary;

        player.transform.position = exitPos.position + (Vector3)playerPosOffset;
    }

    private void KeyNotUseBtn()
    {
        mapChangeUI.SetActive(false);
        yesButtonUI.GetComponent<Button>().onClick.RemoveListener(YesBtn);
        NoButtonUI.GetComponent<Button>().onClick.RemoveListener(NoBtn);
        yesButtonUI.SetActive(false);
        NoButtonUI.SetActive(false);
    }

    //맵 바꿀 때 쓰이는 함수
    private void YesBtn()
    {
        Time.timeScale = 1;
        mapChangeUI.SetActive(false);
        yesButtonUI.GetComponent<Button>().onClick.RemoveListener(YesBtn);
        NoButtonUI.GetComponent<Button>().onClick.RemoveListener(NoBtn);
        yesButtonUI.SetActive(false);
        NoButtonUI.SetActive(false);

        if(uiCheck == true)
            StartCoroutine(StartFadeCoroutine());
        cam.minCameraBoundary = newMinCameraBoundary;
        cam.maxCameraBoundary = newMaxCameraBoundary;

        player.transform.position = exitPos.position + (Vector3)playerPosOffset;
        
        moveScript.playerAnim.SetFloat("lastMoveY",-1);
    }

    private void NoBtn()
    {
        Time.timeScale = 1;
        mapChangeUI.SetActive(false);
        yesButtonUI.GetComponent<Button>().onClick.RemoveListener(YesBtn);
        NoButtonUI.GetComponent<Button>().onClick.RemoveListener(NoBtn);
        yesButtonUI.SetActive(false);
        NoButtonUI.SetActive(false);
    }
}
