using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public bool playOnStart = true;
    SoundEmitter emitter;

    [Header("you can ignore this")]
    public AudioSource source;// if this is not null, we use the overload version of setupsound data to utilize a different audio source

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<SoundEmitter>();
        SoundManagerSingleton.Instance.StopAllLoopingBGM();
        if(playOnStart && emitter != null)
        {
            if (source != null)
            {
                emitter.SetUpSoundData(source);
                emitter.PlaySound();
            }
            else
            {
                emitter.SetUpSoundData();
                emitter.PlaySound();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
