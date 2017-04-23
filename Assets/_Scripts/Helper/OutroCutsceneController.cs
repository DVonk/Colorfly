using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroCutsceneController : MonoBehaviour
{
    public float showDevDelay;
    public float showTitleDelay;
    public float startCameraDelay;
    public float ldDelay;

    public GameObject devText;
    public GameObject titleText;
    public GameObject ldText;

    // Use this for initialization
    void Start()
    {
        Invoke("ShowDev", showDevDelay);
        Invoke("ShowTitle", showTitleDelay);
        Invoke("ShowLD", ldDelay);

        StartCoroutine(BGMManager.instance.FadeIn());
        BGMManager.instance.PlayBGM("Outro");
    }

    void ShowDev()
    {
        devText.SetActive(true);
    }

    void ShowLD()
    {
        ldText.SetActive(true);
    }

    void ShowTitle()
    {
        titleText.SetActive(true);
    }


}
