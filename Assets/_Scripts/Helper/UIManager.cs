using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    GameObject spaceBarUI;
    GameObject faderPanel;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        IntroCameraController control = FindObjectOfType<IntroCameraController>();

        if (control != null)
        {
            Destroy(FindObjectOfType<IntroCameraController>().gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {
        spaceBarUI = GameObject.Find("PressSpace");
        spaceBarUI.SetActive(false);

        faderPanel = GameObject.Find("FaderPanel");
        faderPanel.GetComponent<FaderPanel>().StartFading();
    }

    public void ToggleSpacebar()
    {
        spaceBarUI.SetActive(!spaceBarUI.activeSelf);
    }

    public void FadeIn()
    {
        faderPanel.GetComponent<FaderPanel>().FadeIn();
    }

    public void FadeOut(string nextSceneName, float speed = 7f)
    {
        StartCoroutine(StartFadingOut(nextSceneName, speed));
    }




    IEnumerator StartFadingOut(string nextSceneName, float speed)
    {
        yield return StartCoroutine(faderPanel.GetComponent<FaderPanel>().FadeOut(speed));

        GameController.instance.ChangeLevel(nextSceneName);
    }


}
