using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMove : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    public float playerSpeed;

    public Vector2 saveMaxPos;
    public Vector2 saveMinPos;

    /*public TMP_Text DiaryText;
    public GameObject DialogPanel;

    public Demo demo;   //Helen's Diary Interaction Script
    public Demo demo2;  //Mia

    public GameObject HelenDiary;
    public GameObject MiaDiary;

    bool Helen = false;
    bool Mia = false;*/

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //�÷��̾� ������
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerSpeed * Time.deltaTime;

        //�÷��̾� �̵� �ִϸ��̼�
        playerAnim.SetFloat("MoveX", playerRb.velocity.x);
        playerAnim.SetFloat("MoveY", playerRb.velocity.y);

        //���⿡ ��ġ�ϴ� Idle �ִϸ��̼� ������ ���� lastMoveX/Y ������ ����
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HelenDiary")
        {
            DialogPanel.SetActive(true);
            DiaryText.text = "�ﷻ�� �ϱ����̴�. �о��?";
            Helen = true;
        }

        if (collision.tag == "MiaDiary")
        {
            DialogPanel.SetActive(true);
            DiaryText.text = "�̾��� �ϱ����̴�. �о��?";
            Mia = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HelenDiary")
        {
            HelenDiary.SetActive(false);
            Helen = false;
        }

        if (collision.tag == "MiaDiary")
        {
            MiaDiary.SetActive(false);
            Mia = false;
        }
    }*/

    IEnumerator Walking()
    {
        yield return new WaitForSeconds(0.1f);
        playerAnim.SetBool("walk", false);
    }

    /*public void ShowDiary()
    {
        if (Helen)
        {
            demo.currentPage = 0;   //if player activate the diary, player can see fist page of the diary
            demo.UpdatePage();
            HelenDiary.SetActive(true);
            DialogPanel.SetActive(false);
        }

        if (Mia)
        {
            demo2.currentPage = 0;   //if player activate the diary, player can see fist page of the diary
            demo2.UpdatePage();
            MiaDiary.SetActive(true);
            DialogPanel.SetActive(false);
        }
    }

    public void ShowHelen()
    {
        demo.currentPage = 0;   //if player activate the diary, player can see fist page of the diary
        demo.UpdatePage();
        HelenDiary.SetActive(true);
        DialogPanel.SetActive(false);
    }

    public void ShowMia()
    {
        demo2.currentPage = 0;   //if player activate the diary, player can see fist page of the diary
        demo2.UpdatePage();
        MiaDiary.SetActive(true);
        DialogPanel.SetActive(false);
    }

    public void NoBtn()
    {
        DialogPanel.SetActive(false);
    }*/
}
