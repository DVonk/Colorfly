using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public List<Text> texts;

    private void Start()
    {
        BGMManager.instance.PlayBGM("Menu");
        BGMManager.instance.FadeIn();
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Cursor.visible = false;
        StartCoroutine(FadeToGame());      
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator FadeToGame()
    {
        SFXManager.instance.Play("Ok", false);
        foreach (Text text in texts)
            text.GetComponent<TextFader>().FadeOut();

        yield return StartCoroutine(BGMManager.instance.FadeOut());
        SceneManager.LoadScene("02_Intro");
    }
}
