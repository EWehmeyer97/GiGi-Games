using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    public bool keepAlive = true;
    public bool onlyOnEnable = false;

    private static T _instance = null;
    public static T Instance {
        get { 
            return _instance;
        }
    }

    static public bool isInstanceAlive
    {
        get { return _instance != null; }
    }

    public virtual void Awake()
    {
        if (!onlyOnEnable)
            Setup();
    }

    public virtual void OnEnable()
    {
        if (onlyOnEnable)
            Setup();
    }

    public virtual void OnDisable() 
    {
        if (onlyOnEnable)
            _instance = null;
    }

    private void Setup()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<T>();
            if (keepAlive && !onlyOnEnable)
                DontDestroyOnLoad(gameObject);
        }
    }
}