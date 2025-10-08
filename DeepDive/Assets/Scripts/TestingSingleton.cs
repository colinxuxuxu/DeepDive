using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerSingleton.Instance.DebugInstance();
    }

}
