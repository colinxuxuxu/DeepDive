using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManagerSingleton : Singleton<SoundManagerSingleton>
{
    public GameObject soundGameObject;
    // records all looping BGM to control their lifespan
    public List<SoundEmitter> loopingBGM = new List<SoundEmitter>();

    private void Start()
    {
        SoundEmitter emitter = FindFirstObjectByType<SoundEmitter>();
        soundGameObject = Resources.Load<GameObject>("SoundGameObject");
        if (emitter != null)
        {           
            // check if we should keep track of a looping bgm
            if(emitter.soundData != null)
            {
                if (emitter.soundData.shouldLoop && emitter.soundData.isBGM)
                {
                    loopingBGM.Add(emitter);
                }
            }
            // playsound once
            //emitter.PlaySound();
        }
    }

    public void SearchForSoundGameObjectReference()
    {
        SoundEmitter emitter = FindFirstObjectByType<SoundEmitter>();
        if (emitter != null)
        {
            soundGameObject = emitter.gameObject;

            // playsound once
            //emitter.PlaySound();
        }
    }

    public void StopLoopingBGM(string soundName)
    {
        // trying to find the sound and stop it
        foreach (SoundEmitter emitter in loopingBGM)
        {
            if (emitter.soundData != null)
            {
                if (emitter.soundData.audioName.Equals(soundName))
                {
                    loopingBGM.Remove(emitter);
                    emitter.StopSound();
                }
            }
        }
    }

    public void StopAllLoopingBGM()
    {
        foreach (SoundEmitter emitter in loopingBGM)
        {
            //loopingBGM.Remove(emitter);
            emitter.StopSound();
        }
    }

    public void DebugInstance()
    {
        Debug.Log("I am here!");
    }

    public SoundEmitter PlaySound(Sound sound)
    {
        if (soundGameObject != null)
        {
            GameObject soundPrefab = Instantiate(soundGameObject, transform.position, transform.rotation);
            SoundEmitter emitter = soundPrefab.GetComponent<SoundEmitter>();
            if (emitter != null)
            {
                // check if we should keep track of a looping bgm
                if (sound.shouldLoop && sound.isBGM)
                {
                    loopingBGM.Add(emitter);
                }
                emitter.soundData = sound;
                emitter.SetUpSoundData();
                emitter.PlaySound();
                return emitter;
            }
        }
        return null;
    }
}
