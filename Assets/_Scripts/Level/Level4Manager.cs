using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Manager : MonoBehaviour {

    int currentPickups = 0;
    bool warpSpawned = false;

    public int treesBuilt = 0;


    // Use this for initialization
    void Start()
    {
        BGMManager.instance.PlayBGM("BGM02");
        StartCoroutine(BGMManager.instance.FadeIn());
        GameController.instance.ResetPickups();
        GameController.instance.TogglePlayAltSFX(true);
        GameController.instance.ResetWarpSFX();
        FindObjectOfType<PlayerController>().freeze = true;
    }

    private void Update()
    {
        if (currentPickups >= 14 && !warpSpawned)
        {
            FindObjectOfType<WarpChecker>().Activate();
            warpSpawned = true;
        }
    }

    public void PickupCollected()
    {
        currentPickups++;
    }

    public void CutsceneDone()
    {
        FindObjectOfType<PlayerController>().SetSpeed(17f);
        FindObjectOfType<PlayerController>().freeze = false;
    }

    public void ResetTrees()
    {
        GameController.instance.AddTreesBuilt(-treesBuilt);
    }


}
