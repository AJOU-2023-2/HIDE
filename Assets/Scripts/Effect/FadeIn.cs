using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(fadeStart());
    }

    IEnumerator fadeStart()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,fadeCount);
        }
    }
}
