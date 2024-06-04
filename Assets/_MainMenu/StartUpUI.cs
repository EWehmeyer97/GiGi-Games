using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpUI : Singleton<StartUpUI>
{
    [SerializeField] private GameObject signUpScreen;
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject homeScreen;
    public void LoadMenu()
    {
        if (FirebaseInit.Instance.IsConnected)
        {
            if (FirebaseInit.Instance.Auth.CurrentUser != null)
                LoadHome();
            else
                LoadSignUp();
        }
    }

    public void LoadHome()
    {
        PlayerData.Instance.SetPlayer();
        homeScreen.SetActive(true);
        loginScreen.SetActive(false);
        signUpScreen.SetActive(false);
    }

    public void LoadLogin()
    {
        homeScreen.SetActive(false);
        loginScreen.SetActive(true);
        signUpScreen.SetActive(false);
    }

    public void LoadSignUp()
    {
        homeScreen.SetActive(false);
        loginScreen.SetActive(false);
        signUpScreen.SetActive(true);
    }
}
