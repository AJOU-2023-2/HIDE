using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMove : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private bool check;

    public GameObject targetPos;
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("walk", true);
        check = true;
    }

    void Update()
    {
        if(check != true)
        {
            playerAnim.SetBool("walk", false);
            StartCoroutine(Chatting());
        }else
        {
            Walk();
        }
    }

    void Walk()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos.transform.position, 2 * Time.deltaTime);
        if(transform.position == targetPos.transform.position)
            check = false;
    }

    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(2f);
        textpanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterName.SetActive(true);
        yield return new WaitForSeconds(1f);
        characterText.SetActive(true);
    }
}
