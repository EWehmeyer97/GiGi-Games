using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpUI : MonoBehaviour
{
    [SerializeField] private GameObject signUpScreen;
    [SerializeField] private GameObject homeScreen;
    public void LoadMenu()
    {
        if (FirebaseInit.Instance.IsConnected)
        {
            
        }
    }
}
