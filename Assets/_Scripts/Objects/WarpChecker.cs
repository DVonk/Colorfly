using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpChecker : MonoBehaviour
{
    int buildablesBuilt = 0;

    public int requirement = 2;

    public GameObject portalAppearedText;
    public GameObject warp;

    private void Update()
    {
        if (buildablesBuilt >= requirement)
        {
            warp.SetActive(true);
            portalAppearedText.SetActive(true);
            StartCoroutine(BGMManager.instance.FadeOut());
            Destroy(gameObject);
        }
    }

    public void AddBuilt()
    {
        buildablesBuilt++;
    }

    public void Activate()
    {
        buildablesBuilt = 1000;
    }

    

}
