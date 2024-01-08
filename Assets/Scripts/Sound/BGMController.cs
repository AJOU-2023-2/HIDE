using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    static public BGMController instance;
    public GameObject BGM;
    private AudioSource audio;

    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audioClip;
    }

    public BgmType[] BGMList;
    public bool change = true;

    void Start()
    {
        audio = BGM.GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(BGM);    //keep playing audio when the scene is changed
        }
        else Destroy(BGM); //keep playing audio when the scene is changed

        ChangeBGM();
        change = false;
    }

    void Update()
    {
        ChangeBGM();
    }

    void ChangeBGM()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5 && change == true)
        {
            audio.clip = BGMList[0].audioClip;
            audio.Play();
            change = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex <= 4 && change == true)
        {
            audio.clip = BGMList[1].audioClip;
            audio.Play();
            change = false;
        }
    }
}
