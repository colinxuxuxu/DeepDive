using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();
                if (instance == null)
                {
                    GameObject gameObj = new GameObject("Singleton");
                    instance = gameObj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // check if there's a valid sound manger now
        if (instance == null)
        {
            instance = this as T;
        }
        else // if there is destroy the current one we are trying to make
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
