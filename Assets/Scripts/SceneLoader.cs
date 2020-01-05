using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainScene()
    {

        SceneManager.LoadScene("Main Scene");
        if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("MenuScene"))
        {
               FindObjectOfType<GameSession>().Awake();
        }
    }

    public void LoadUnsavedMainScene()
    {
        SaveSystem.DeleteSaved();
        LoadMainScene();
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
