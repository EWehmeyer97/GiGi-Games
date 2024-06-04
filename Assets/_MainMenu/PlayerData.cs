using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private string userID;
    public string UserID
    {
        get { return userID; }
    }

    private string displayName;
    public string DisplayName
    {
        get { return displayName; }
    }

    public void SetPlayer()
    {
        FirebaseUser currentUser = FirebaseInit.Instance.Auth.CurrentUser;
        userID = currentUser.UserId;
        displayName = currentUser.DisplayName;
    }

    public void UpdatePlayer(string name)
    {
        displayName = name;
        UserProfile info = new UserProfile();
        info.DisplayName = displayName;
        FirebaseInit.Instance.Auth.CurrentUser.UpdateUserProfileAsync(info);
    }
}
