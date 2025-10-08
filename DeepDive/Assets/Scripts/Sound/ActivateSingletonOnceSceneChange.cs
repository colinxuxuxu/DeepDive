using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSingletonOnceSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerSingleton.Instance.SearchForSoundGameObjectReference();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
