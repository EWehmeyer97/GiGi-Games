using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadHome()
    {
        SceneManager.LoadScene(1);
    }
}
