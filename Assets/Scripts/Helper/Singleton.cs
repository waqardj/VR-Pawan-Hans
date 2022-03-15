using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    [SerializeField] bool _doNotDestroy;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (_doNotDestroy)
                DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
