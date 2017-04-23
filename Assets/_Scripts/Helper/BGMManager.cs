using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance = null;
    AudioSource audioSource;

    public List<AudioClip> songs;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

    }
    
    public void PlayBGM(string name)
    {
        foreach (AudioClip clip in songs)
        {
            if (clip.name == name)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }

        }
    }

    public IEnumerator FadeOut()
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / 4f;
            yield return null;
        }

    }

    public void FadeThisOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOutFast()
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / 1f;
            yield return null;
        }

    }

    public IEnumerator FadeIn()
    {
        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / 2f;
            yield return null;
        }

    }

    public void ToggleLoop()
    {
        audioSource.loop = !audioSource.loop;
    }


    public void ToggleLoop(bool value)
    {
        audioSource.loop = value;
    }
}
