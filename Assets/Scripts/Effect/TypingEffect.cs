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
    private int _dialogNum;

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
    public GameObject tom;


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
                    player.SetActive(true);
                }else{
                    textpanel.SetActive(false);
                    characterText.SetActive(false);
                    characterName.SetActive(false);
                    characterImage.SetActive(false);
                    player.SetActive(true);
                }
                //player.GetComponent<Move>().enabled = true;
            }
        }
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
