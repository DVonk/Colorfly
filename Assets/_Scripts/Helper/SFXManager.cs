using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;

public class SFXManager : MonoBehaviour
{
    //Main
    public static SFXManager instance = null;
    public GameObject oneShotPlayer;

    //Songs
    public List<AudioClip> clips;

    private void Awake()
    {
        //Singleton
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    //Play clip by name
    public void Play(string clipName, bool randomPitch)
    {
        if (GameController.instance.GetPlaySFX())
        {
            GameObject obj = Instantiate(oneShotPlayer);
            obj.gameObject.transform.SetParent(transform);
            AudioSource player = obj.GetComponent<AudioSource>();

            //Nach Clip suchen
            foreach (AudioClip clip in clips)
                if (clip.name == clipName)
                {
                    player.clip = clip;
                    if (randomPitch)
                    {
                        player.pitch = Random.Range(0.98f, 1.02f);
                    }
                    player.PlayOneShot(clip);
                    Destroy(obj, clip.length);
                }

            if (player.clip == null)
                Debug.LogWarning("Clip nicht gefunden: " + clipName);
        }
    }

    //Play clip by name
    public void Play(string clipName, bool randomPitch, float volume)
    {
        if (GameController.instance.GetPlaySFX())
        {
            GameObject obj = Instantiate(oneShotPlayer);
            obj.gameObject.transform.SetParent(transform);
            AudioSource player = obj.GetComponent<AudioSource>();

            //Nach Clip suchen
            foreach (AudioClip clip in clips)
                if (clip.name == clipName)
                {
                    player.clip = clip;
                    if (randomPitch)
                    {
                        player.pitch = Random.Range(0.98f, 1.02f);
                    }

                    player.volume = volume;
                    player.PlayOneShot(clip);
                    Destroy(obj, clip.length);
                }

            if (player.clip == null)
                Debug.LogWarning("Clip nicht gefunden: " + clipName);
        }
    }
}
