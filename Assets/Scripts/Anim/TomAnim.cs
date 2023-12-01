using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomAnim : MonoBehaviour
{
    private Rigidbody2D tomRb;
    public Animator tomAnim;
    public bool incheck;    //애니메이션 전환 체크
    private bool check;     //톰이 걸어오는 애니메이션 체크
    private bool check2;    //톰이 퇴장하는 애니메이션 체크
    private bool check3;    //톰 독백 체크
    
    private Vector3 tompos;

    //톰 독백
    public GameObject targetPos;
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;

    public GameObject player;
    public GameObject player2;

    //톰 나가고 난 후 주인공 독백
    public GameObject playerText;
    public GameObject playerName;

    void Awake()
    {
        tompos = this.gameObject.transform.position;
        tomRb = GetComponent<Rigidbody2D>();
        tomAnim = GetComponent<Animator>();
        tomAnim.SetBool("walk", true);
        check = true;
        check2 = true;
        check3 = true;
        incheck = true;
    }

    void Update()
    {
        if(incheck)
        {
            if(check != true)
            {
                tomAnim.SetBool("walk", false);
                player.SetActive(false);
                player2.transform.position = player.transform.position;
                player2.SetActive(true);
                if(check3)
                {
                    StartCoroutine(Chatting());
                    check3 = false;
                }
                
            }else
            {
                Walk();
            }
        }else {
            if(check2 != true)
            {
                StartCoroutine(Chatting2());
            }else
            {
                Walk2();
            }
        }
    }

    //톰이 플레이어에게 걸어오는 장면
    void Walk()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(targetPos.transform.position.x , targetPos.transform.position.y + 1, targetPos.transform.position.z), 10 * Time.deltaTime);
        if(transform.position == new Vector3(targetPos.transform.position.x , targetPos.transform.position.y + 1, targetPos.transform.position.z))
            check = false;
    }

    //톰이 퇴장하는 장면
    void Walk2()
    {
        transform.position = Vector2.MoveTowards(transform.position, tompos, 10 * Time.deltaTime);
        if(transform.position == tompos)
            check2 = false;
    }

    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(2f);
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.SetActive(true);
    }

    IEnumerator Chatting2()
    {
        yield return new WaitForSeconds(1f);
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerName.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerText.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
