using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderPanel : MonoBehaviour
{
    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        img.color = Color.black;
    }

    public void StartFading()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadingOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        while (img.color.a > 0f)
        {
            Color newColor = img.color;
            newColor.a -= Time.deltaTime / 2f;
            img.color = newColor;
            yield return null;
        }


    }

    public IEnumerator FadeOut()
    {
        gameObject.SetActive(true);

        while (img.color.a < 1f)
        {
            Color newColor = img.color;
            newColor.a += Time.deltaTime / 7f;
            img.color = newColor;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float speed)
    {
        gameObject.SetActive(true);

        while (img.color.a < 1f)
        {
            Color newColor = img.color;
            newColor.a += Time.deltaTime / speed;
            img.color = newColor;
            yield return null;
        }
    }
}
