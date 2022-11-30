using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] float timeToSwitch;

    [SerializeField] AudioClip playToStart;
    //[SerializeField] AudioClip audioClip2;
    private void Start()
    {
        Play(playToStart, true);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Play(audipClip);
    //    }
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        Play(audioClip2);
    //    }
    //}

    private void Play(AudioClip musicToPlay, bool interrupt = false)
    {
        Debug.Log("why");
        if (musicToPlay == null) { return; }

        if (interrupt == true)
        {
            audioSource.volume = 1f;
            audioSource.clip = musicToPlay;
            audioSource.Play();
        }
        else
        {
            switchTo = musicToPlay;
            StartCoroutine(SmoothSwitchMusic());
        }
    }

    AudioClip switchTo;
    float volume;
    IEnumerator SmoothSwitchMusic()
    {
        volume = 1f;
        while (volume > 0f)
        {
            volume -= Time.deltaTime; /// timeToSwitch;
            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }
        Play(switchTo, true);
    }
}
