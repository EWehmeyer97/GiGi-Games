using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FirebaseConfig : MonoBehaviour
{
    public UnityEvent OnConfigDecline = new UnityEvent();

    private void Awake()
    {
        CheckRemoteConfigValues();
    }

    public Task CheckRemoteConfigValues()
    {
        Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

    private void FetchComplete(Task fetchTask)
    {
        if (!fetchTask.IsCompleted)
            return;

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;

        if (info.LastFetchStatus != LastFetchStatus.Success)
            return;

        remoteConfig.ActivateAsync().ContinueWithOnMainThread(
            task => {
                var value = remoteConfig.GetValue("Game_Version");
                if(Application.version != value.StringValue)
                {
                    OnConfigDecline.Invoke();
                } else
                {
                    SceneManager.LoadScene(1);
                }
        });
    }
}
