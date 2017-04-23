using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollManager : MonoBehaviour {

    public string bgm;

    // Use this for initialization
    void Start () {
        BGMManager.instance.ToggleLoop();
        BGMManager.instance.PlayBGM(bgm);
        StartCoroutine(BGMManager.instance.FadeIn());
        UIManager.instance.FadeIn();

       
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.GetAltSFX() == false)
        {
            GameController.instance.TogglePlayAltSFX(true);
            GameController.instance.ResetPickups();

        }

    }
}
