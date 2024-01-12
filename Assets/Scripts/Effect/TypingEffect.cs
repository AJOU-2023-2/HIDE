using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> _dialog = new List<string>();
    public int _dialogNum;

    public int CharPerSeconds;
    private string targetmsg;
    private int index;
    private float interval;
    private bool isEffect;

    //텍스트 이펙트없이 다 보이게 해주는 기능을 위한 변수
    private bool msgCheck;
    private int _dialogNum2;

    //인게임
    public GameObject textpanel;
    public GameObject characterText;
    public GameObject characterName;
    public GameObject characterImage;
    public GameObject player;

    public GameObject player2;
    public GameObject player3;
    public GameObject tom;
    public GameObject phase2;

    public GameObject endingText;
    public GameObject backgroundPanel;
    public GameObject image;
    public GameObject paperImage;
    public GameObject textPanel;
    public GameObject storybtn;
    public GameObject credit;
    public TextMeshProUGUI storytext;

    //인벤토리, 메모장 버튼 활성화
    public GameObject invenBtn;
    public GameObject memoBtn;

    void Start()
    {
        _dialogNum = 0;
        _dialogNum2 = 0;
        msgCheck = true;
        NextDialog();
        interval = 1.0f / CharPerSeconds;
    }

    void OnEnable()
    {
        _dialogNum = 0;
        _dialogNum2 = 0;
        msgCheck = true;
        NextDialog();
        interval = 1.0f / CharPerSeconds;
    }

    public void NextDialog()
    {
        if(!msgCheck)
        {
            Setmsg2(_dialog[_dialogNum2]);
            msgCheck = true;
            _dialogNum2++;
        }else {
            if(_dialogNum < _dialog.Count)
            {
                Setmsg(_dialog[_dialogNum]);
                _dialogNum++;
                msgCheck = false;
            } else
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                    SceneManager.LoadScene("MainIntro");
                if (SceneManager.GetActiveScene().buildIndex == 2)
                    SceneManager.LoadScene("MainGame");
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    //페이지2 넘어가기전 톰이 달려오는 장면 애니메이션 실행
                    if(this.gameObject.tag == "Monologue")
                    {
                        tom.GetComponent<TomAnim>().incheck = false;
                        tom.GetComponent<TomAnim>().tomAnim.SetBool("walk2", true);
                        textpanel.SetActive(false);
                        characterName.SetActive(false);
                        characterText.SetActive(false);
                    }else if(this.gameObject.tag == "Monologue2")
                    {
                        textpanel.SetActive(false);
                        characterText.SetActive(false);
                        characterName.SetActive(false);
                        player2.SetActive(false);
                        player3.SetActive(true);
                    }else if(this.gameObject.tag == "PhaseChange")
                    {
                        SceneManager.LoadScene("MainGame_pg2");
                    }else{
                        textpanel.SetActive(false);
                        characterText.SetActive(false);
                        characterName.SetActive(false);
                        characterImage.SetActive(false);
                        player.SetActive(true);
                    }
                }
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    textpanel.SetActive(false);
                    characterText.SetActive(false);
                    if(characterName != null)
                        characterName.SetActive(false);
                    if(characterImage != null)
                        characterImage.SetActive(false);
                    player.SetActive(true);
                    if(invenBtn != null && memoBtn != null)
                    {
                        invenBtn.SetActive(true);
                        memoBtn.SetActive(true);
                    }
                    //보이스 관련 패널 활성화
                    if(phase2 != null)
                        phase2.SetActive(true);
                }
                if (SceneManager.GetActiveScene().buildIndex == 5 && _dialog.Count == 11)
                {
                    backgroundPanel.SetActive(true);
                    image.SetActive(false);
                    paperImage.SetActive(false);
                    textPanel.SetActive(false);
                    StartCoroutine(CreditOn());
                    storybtn.SetActive(false);
                    storytext.text = "";
                }
            }
        }
    }

    IEnumerator CreditOn()
    {
        yield return new WaitForSeconds(0.5f);
        endingText.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingText.SetActive(false);
        credit.SetActive(true);
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("Title");
    }

    public void Setmsg(string msg)
    {
        if(isEffect)
        {
            CancelInvoke();
            EffectEnd();
        }
        targetmsg = msg;
        EffectStart();
    }

    void Setmsg2(string msg)
    {
        if(isEffect)
        {
            CancelInvoke();
            EffectEnd();
        }
        text.text = msg;
    }

    void EffectStart()
    {
        text.text = "";
        index = 0;
        isEffect = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(text.text == targetmsg)
        {
            EffectEnd();
            return;
        }

        text.text += targetmsg[index];
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isEffect = false;
    }
}
