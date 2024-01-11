using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgm;
    public Slider effect;


    public void SetBGM()
    {
        audioMixer.SetFloat("Music", Mathf.Log10(bgm.value) * 20);
        //control the bgm sound

    }

    public void SetEffect()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(effect.value) * 20);    //control the Effect sound
    }
}
