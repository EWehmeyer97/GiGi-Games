using Firebase;
using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    private static FirebaseInit _instance;
    public static FirebaseInit Instance
    {
        get
        {
            return _instance;
        }
    }

    private FirebaseAuth _auth;
    public FirebaseAuth Auth
    {
        get
        {
            if(_auth == null)
            {
                _auth = FirebaseAuth.GetAuth(App);
            }

            return _auth;
        }
    }

    private FirebaseApp _app;
    public FirebaseApp App
    {
        get
        {
            return _app;
        }
    }

    private bool _isConnected = false;
    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
    }

    public UnityEvent OnFirebaseInit = new UnityEvent();

    private async void Start()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
            var dependent = await FirebaseApp.CheckAndFixDependenciesAsync();
            if(dependent == DependencyStatus.Available)
            {
                _app = FirebaseApp.DefaultInstance;
                _isConnected = true;
            } else
            {
                _isConnected = false;
            }
        } else
        {
            Destroy(gameObject);
        }

        OnFirebaseInit.Invoke();
    }

    private void OnDestroy()
    {
        _auth = null;
        _app = null;
        if(_instance == this)
        {
            _instance = null;
        }
    }
}
