using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPuzzle : MonoBehaviour
{
    public int touchCount = 0;
    public float timer = 0f;
    private bool gameClear = false;

    void Update()
    {
        if (touchCount > 0)
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
            // 여기에 게임 클리어 후의 로직을 추가할 수 있습니다.
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
}
