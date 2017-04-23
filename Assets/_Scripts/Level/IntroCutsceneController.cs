using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutsceneController : MonoBehaviour
{
    public float showDevDelay;
    public float showTitleDelay;
    public float startCameraDelay;

    public GameObject devText;
    public GameObject titleText;

    // Use this for initialization
    void Start()
    {
        Invoke("ShowDev", showDevDelay);
        Invoke("ShowTitle", showTitleDelay);
        Invoke("StartCameraMovement", startCameraDelay);

        StartCoroutine(BGMManager.instance.FadeIn());
        BGMManager.instance.PlayBGM("Intro");
    }

    void ShowDev()
    {
        devText.SetActive(true);
    }

    void ShowTitle()
    {
        titleText.SetActive(true);
    }

    void StartCameraMovement()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("IntroMovement");
    }
}
