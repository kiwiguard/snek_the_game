using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Score.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Gets next scene index from buildmanager.
    }

    public void QuitGame()
    {
        Score.score = 0;
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
