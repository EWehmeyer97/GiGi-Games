using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogInUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;

    public void Login_OnClick()
    {
        StartCoroutine(LoginUser(emailField.text, passwordField.text));
    }

    private IEnumerator LoginUser(string email, string password)
    {
        var registerTask = FirebaseInit.Instance.Auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            //TODO - Something went wrong, account for this
        }
        else
        {
            StartUpUI.Instance.LoadHome();
        }
    }
}
