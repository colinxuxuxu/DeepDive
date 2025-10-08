using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData")]
public class Sound : ScriptableObject
{
    public string audioName;
    public AudioClip clip;
    public bool shouldLoop = false;
    //public AudioSource source;
    public float volume;
    public bool is3D = false;
    public bool isBGM = false;
    public Transform soundLoc; // only used if this is a 3d sound
    public float fadeOutDuration = 0.0f;
    public float soundCooldown = 3.0f;
}
