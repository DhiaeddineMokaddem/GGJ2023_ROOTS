using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Train()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
