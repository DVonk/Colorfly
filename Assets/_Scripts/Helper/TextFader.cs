using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void FadeOut()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        while (text.color.a > 0f)
        {
            Color currentColor = text.color;
            currentColor.a -= Time.deltaTime / 2f;
            text.color = currentColor;
            yield return null;
        }

    }
}
