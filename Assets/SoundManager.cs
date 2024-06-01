using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float timeToSwitch;
    [SerializeField] AudioClip playOnstart;
    [SerializeField] AudioClip audioClip2;

    private void Start()
    {
        Play(playOnstart, true);
    }
    public void Play(AudioClip musicToPlay, bool interrupt = false)
    {
        if (musicToPlay == null) return;
        if( interrupt == true )
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
        while(volume > 0f)
        {
            volume -= Time.deltaTime/timeToSwitch;
            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }
        Play(switchTo, true);
    }
}
