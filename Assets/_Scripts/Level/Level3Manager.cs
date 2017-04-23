using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BGMManager.instance.PlayBGM("BGM01");
        StartCoroutine(BGMManager.instance.FadeIn());
        GameController.instance.ResetPickups();
        GameController.instance.TogglePlayAltSFX(false);
        GameController.instance.ResetWarpSFX();
        FindObjectOfType<PlayerController>().SetSpeed(15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
