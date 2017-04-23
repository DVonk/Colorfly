using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    Text blueText;
    Text yellowText;
    Text redText;

    private int blueCount = 0;
    private int yellowCount = 0;
    private int redCount = 0;

    private int treeCount = 0;

    public int lastPickupSFXNumber = 8;
    public int lastWarpSFXNumber = 6;

    public bool tutorial = true;
    bool playSFX = true;
    public bool playAltSFX = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }


    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }


    private void Update()
    {
        if (blueText != null && yellowText != null && redText != null)
        {
            blueText.text = blueCount.ToString();
            yellowText.text = yellowCount.ToString();
            redText.text = redCount.ToString();
        }
        else
        {
            GameObject textObject;
            textObject = GameObject.Find("BlueText");
            if (textObject != null)
                blueText = textObject.GetComponent<Text>();

            textObject = GameObject.Find("RedText");
            if (textObject != null)
                redText = textObject.GetComponent<Text>();

            textObject = GameObject.Find("YellowText");
            if (textObject != null)
                yellowText = textObject.GetComponent<Text>();
        }

    }

    public void AddBlue(int value)
    {
        blueCount += value;
    }

    public void AddYellow(int value)
    {
        yellowCount += value;
    }

    public void AddRed(int value)
    {
        redCount += value;
    }

    public int GetBlue()
    {
        return blueCount;
    }

    public int GetYellow()
    {
        return yellowCount;
    }

    public int GetRed()
    {
        return redCount;
    }

    public void PayCost(int blue, int yellow, int red)
    {
        blueCount -= blue;
        yellowCount -= yellow;
        redCount -= red;
    }

    public void ResetPickupSFX()
    {
        lastPickupSFXNumber = 8;
    }

    public void ResetWarpSFX()
    {
        lastPickupSFXNumber = 6;
    }

    public void TreeBuilt()
    {
        treeCount++;
    }

    public void AddTreesBuilt(int trees)
    {
        treeCount += trees;
    }

    public void ResetPickups()
    {
        blueCount = 0;
        redCount = 0;
        yellowCount = 0;
    }

    public bool GetPlaySFX()
    {
        return playSFX;
    }

    public void TogglePlaySFX(bool value)
    {
        playSFX = value;
    }

    public bool GetAltSFX()
    {
        return playAltSFX;
    }

    public void TogglePlayAltSFX(bool value)
    {
        playAltSFX = value;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public int GetTreeCount()
    {
        return treeCount;
    }
}
