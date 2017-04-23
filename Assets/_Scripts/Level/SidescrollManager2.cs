using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollManager2 : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        BGMManager.instance.ToggleLoop();
        BGMManager.instance.PlayBGM("PianoImprov");
        StartCoroutine(BGMManager.instance.FadeIn());
        UIManager.instance.FadeIn();
        GameController.instance.TogglePlayAltSFX(true);
        GameController.instance.ResetPickups();

    }

    // Update is called once per frame
    void Update()
    {

    }
}