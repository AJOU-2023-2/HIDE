using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffect : MonoBehaviour
{
    public GameObject lightObejct;

    void Update()
    {
        StartCoroutine(Effect());
    }

    IEnumerator Effect()
    {
        lightObejct.SetActive(true);
        yield return new WaitForSeconds(3f);
        lightObejct.SetActive(false);
        yield return new WaitForSeconds(4f);
    }
}
