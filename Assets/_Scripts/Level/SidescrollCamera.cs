using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollCamera : MonoBehaviour
{
    public void FadeBGM()
    {
        StartCoroutine(BGMManager.instance.FadeOut());

    }

}
