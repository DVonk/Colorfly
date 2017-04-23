using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        paused = true;
        BGMManager.instance.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        paused = false;
        BGMManager.instance.GetComponent<AudioSource>().UnPause();
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Unpause();
            else
                Pause();
        }

        if (paused)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                QuitGame();
            }
        }
    }
}
