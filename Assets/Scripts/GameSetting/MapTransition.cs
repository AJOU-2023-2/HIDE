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

    public GameObject roomUI;
    public TextMeshProUGUI roomTextUI;
    public string roomName;
    public bool uiCheck;

    public bool mapChange; //층수 맵 바꾸기 위한 변수
    public GameObject mapChangeUI;
    public GameObject yesButton;

    [SerializeField] Vector2 playerPosOffset;

    [SerializeField] Transform exitPos;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
        moveScript = player.GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(roomName == "1층" || roomName == "2층" || roomName == "지하")
            {
                mapChangeUI.SetActive(true);
                yesButton.SetActive(true);
                Time.timeScale = 0;
            }else {
                if(uiCheck == true)
                    StartCoroutine(StartFadeCoroutine());
                cam.minCameraBoundary = newMinCameraBoundary;
                cam.maxCameraBoundary = newMaxCameraBoundary;

                player.transform.position = exitPos.position + (Vector3)playerPosOffset;
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

    public void YesBtn()
    {
        Time.timeScale = 1;
        mapChangeUI.SetActive(false);
        yesButton.SetActive(false);

        if(uiCheck == true)
            StartCoroutine(StartFadeCoroutine());
        cam.minCameraBoundary = newMinCameraBoundary;
        cam.maxCameraBoundary = newMaxCameraBoundary;

        player.transform.position = exitPos.position + (Vector3)playerPosOffset;
        
        moveScript.playerAnim.SetFloat("lastMoveY",-1);
    }

    public void NoBtn()
    {
        mapChangeUI.SetActive(false);
    }
}
