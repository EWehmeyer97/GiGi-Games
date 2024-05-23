using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SignUpUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TMP_InputField confirmPasswordField;
    
    public void SignUp_OnClick()
    {
        StartCoroutine(RegisterUser(emailField.text, passwordField.text));
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        var registerTask = FirebaseInit.Instance.Auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            
        } else
        {

        }
    }
}
