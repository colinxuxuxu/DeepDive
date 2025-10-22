using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public Sound soundData;
    AudioSource audioSource;
    Transform loc;
    private float nextAvailableTime; // when this sound will be valid again
    void Start()
    {
        nextAvailableTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && soundData != null)
        {
            audioSource.clip = soundData.clip;
            audioSource.volume = soundData.volume;
            audioSource.loop = soundData.shouldLoop;
            if (soundData.is3D)
            {
                loc = soundData.soundLoc;
            }
        }
    }

    public void SetUpSoundData()
    {
        audioSource = GetComponent<AudioSource>();
        if (soundData != null && audioSource != null)
        {
            audioSource.clip = soundData.clip;
            audioSource.volume = soundData.volume;
            audioSource.loop = soundData.shouldLoop;
            if (soundData.is3D)
            {
                loc = soundData.soundLoc;
            }
        }
    }

    public bool GetIsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void SetUpSoundData(AudioSource source)
    {
        audioSource = source;
        if (soundData != null && audioSource != null)
        {
            //audioSource.clip = soundData.clip;
            //audioSource.volume = soundData.volume;
            //audioSource.loop = soundData.shouldLoop;
            if (soundData.is3D)
            {
                loc = soundData.soundLoc;
            }
        }
    }

    public void PlaySound()
    {
        //audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            //try to get the duration of the clip
            float duration = audioSource.clip.length;
            audioSource.Play();

            if (!soundData.shouldLoop)
            {
                //destroys the game object when we are done playing the sound, give .5 second leeway
                Invoke("DestroyObj", duration + 0.5f);
            }
        }
    }

    public void StopSoundWithoutDestroy()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void StopSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            DestroyObj();
        }
    }

    public void StartFadeOut()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            StartCoroutine(FadeOutCoroutine());
        }

    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < soundData.fadeOutDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / soundData.fadeOutDuration);
            yield return null; // Wait for the next frame
        }

        audioSource.volume = 0f; // Ensure volume is exactly 0 at the end
        audioSource.Stop(); // Stop the audio source after fading out
        DestroyObj();
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
