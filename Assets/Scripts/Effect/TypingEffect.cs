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
    string targetmsg;
    int index;
    float interval;
    bool isEffect;

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


    // Start is called before the first frame update
    void Start()
    {
        _dialogNum = 0;
        NextDialog();
        interval = 1.0f / CharPerSeconds;
    }

    public void NextDialog()
    {
        if(_dialogNum < _dialog.Count)
        {
            Setmsg(_dialog[_dialogNum]);
            _dialogNum++;
        } else
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
                SceneManager.LoadScene("MainIntro");
            if (SceneManager.GetActiveScene().buildIndex == 2)
                SceneManager.LoadScene("MainGame");
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
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
                //player.GetComponent<Move>().enabled = true;
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

    IEnumerator CreditOn()
    {
        yield return new WaitForSeconds(0.5f);
        endingText.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingText.SetActive(false);
        credit.SetActive(true);
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("Main Menu (Desktop)");
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
