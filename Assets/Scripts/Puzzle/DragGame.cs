using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGame : MonoBehaviour
{
    public float targetHeight = 10.0f; // 설정한 높이
    public float tolerance = 0.1f; // 허용 오차

    private float currentHeight = 0.0f; // 현재 높이
    private bool isCounting = false; // 카운트 중인지 여부
    private float countDownTime = 10.0f; // 카운트 다운 시간

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            DragObj stackableObject = other.GetComponent<DragObj>();
            currentHeight += stackableObject.GetHeight(); // 물체의 높이 더하기
            if (currentHeight >= targetHeight && !isCounting) // 높이가 목표치에 도달하면 카운트 시작
            {
                isCounting = true;
                InvokeRepeating("CountDown", 0.0f, 1.0f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            DragObj stackableObject = other.GetComponent<DragObj>();
            currentHeight -= stackableObject.GetHeight(); // 물체의 높이 빼기
            if (isCounting && currentHeight < targetHeight) // 높이가 목표치 미만이면 카운트 중단
            {
                isCounting = false;
                CancelInvoke("CountDown");
            }
        }
    }

    void CountDown()
    {
        countDownTime -= 1.0f;
        if (countDownTime <= 0.0f)
        {
            Debug.Log("게임 클리어!");
            isCounting = false;
            CancelInvoke("CountDown");
        }
    }
}
