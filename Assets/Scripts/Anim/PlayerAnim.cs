using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAnim : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool incheck;    //애니메이션 전환 체크1
    private bool incheck2;   //애니메이션 전환 체크2
    private bool incheck3;   //애니메이션 전환 체크3


    private bool check;     //플레이어 걸어가는 장면1
    private bool check2;    //플레이어 왼쪽,오른쪽 확인 장면
    private bool check3;    //플레이어 목적지까지 걸어가는 장면
    private bool check4;    //플레이어 걸어가는 장면2
    private bool check5;    //플레이어 걸어가는 장면2
    
    private Vector3 pos;    //위치 저장1
    private Vector3 pos2;   //위치 저장2

    public GameObject targetPos; //숨기는 위치

    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage; 

    public GameObject clue;

    void Awake()
    {
        pos = this.gameObject.transform.position;
        pos2 = new Vector3(transform.position.x , transform.position.y + 6, transform.position.z);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
        check = true;
        check2 = true;
        check3 = true;
        check4 = true;
        check5 = true;
        incheck = true;
        incheck2 = true;
        incheck3 = true;
    }

    void Update()
    {
        if(incheck)
        {
            if(check != true)
            {
                if(check2)
                {
                    anim.SetBool("walk", false);
                    StartCoroutine(PlayerAnimation());
                    check2 = false;
                }
            }else
            {
                Walk();
            }
        }else if(incheck2){
            if(check3 != true)
            {
                anim.SetBool("walk2", false);
                StartCoroutine(PlayerAnimation2());
            }else
            {
                Walk2();
            }
        }else if(incheck3){
            if(check4 != true)
            {
                anim.SetBool("walk3", false);
                StartCoroutine(PlayerAnimation3());
            }else
            {
                Walk3();
            }
        }else {
            if(check5 != true)
            {
                anim.SetBool("walk4", false);
                StartCoroutine(Chatting());
            }else
            {
                Walk4();
            }
        }
    }

    //플레이어가 걸어오는 장면1
    void Walk()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos2, 2 * Time.deltaTime);
        if(transform.position == pos2)
            check = false;
    }

    //플레이어가 목적지까지 걸어가는 장면
    void Walk2()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos.transform.position, 2 * Time.deltaTime);
        if(transform.position == targetPos.transform.position)
            check3 = false;
    }

    //플레이어가 걸어오는 장면2
    void Walk3()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos2, 2 * Time.deltaTime);
        if(transform.position == pos2)
            check4 = false;
    }

    //플레이어가 걸어오는 장면3
    void Walk4()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, 2 * Time.deltaTime);
        if(transform.position == pos)
            check5 = false;
    }

    //좌우로 살펴보는 애니메이션
    IEnumerator PlayerAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("leftIdle", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("leftIdle", false);
        anim.SetBool("rightIdle", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("rightIdle", false);
        incheck = false;
        anim.SetBool("walk2", true);
    }

    //다시 걸어가는 장면 
    IEnumerator PlayerAnimation2()
    {
        clue.SetActive(true);
        yield return new WaitForSeconds(2f);
        incheck2 = false;
        anim.SetBool("walk3", true);
    }

    IEnumerator PlayerAnimation3()
    {
        yield return new WaitForSeconds(2f);
        incheck3 = false;
        anim.SetBool("walk4", true);
    }

    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(2f);
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        //characterImage.SetActive(true);
        //yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        // characterText.GetComponent<TypingEffect>()._dialog[0] = "Hopefully... someone will reach the truth…";
        // characterText.GetComponent<TMP_Text>().text = characterText.GetComponent<TypingEffect>()._dialog[0];
        characterText.SetActive(true);
        // this.gameObject.SetActive(false);
    }
}
