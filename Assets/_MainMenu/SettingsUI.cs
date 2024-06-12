using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField displayNameField;
    [SerializeField] private Button logoutButton;
    [SerializeField] private Button deleteAccountButton;
    void OnEnable()
    {
        displayNameField.SetTextWithoutNotify(PlayerData.Instance.DisplayName);
    }

    private void Start()
    {
        displayNameField.onEndEdit.AddListener(UpdateDisplayName);
        logoutButton.onClick.AddListener(LogOut);
        deleteAccountButton.onClick.AddListener(DeleteAccount);
    }

    private void LogOut()
    {
        PlayerData.Instance.LogOut();

        SceneLoader.Instance.LoadStart();
    }

    private void DeleteAccount()
    {
        PlayerData.Instance.DeleteAccount();

        SceneLoader.Instance.LoadStart();
    }

    private void UpdateDisplayName(string x)
    {
        PlayerData.Instance.UpdatePlayerName(x);
    }
}
