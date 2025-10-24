using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Audio;

public class ScaryManager : MonoBehaviour
{

    public bool isPlaying = false;

    public AudioSource breathingAudioSource;

    public AudioMixerSnapshot breathingSnapshot;

    public AudioMixerSnapshot normalSnapshot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayBreathing();
    }

    public void PlayBreathing()
    {
        if (!isPlaying)
        {
            breathingAudioSource.Play();
            breathingAudioSource.loop = true;
            isPlaying = true;
            breathingSnapshot.TransitionTo(0.5f);
        }

        else
        {
            breathingAudioSource.Stop();
            breathingAudioSource.loop = false;
            isPlaying = false;
            normalSnapshot.TransitionTo(0.5f);
        }
        
    }
}
