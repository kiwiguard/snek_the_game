using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Score.score = 0;
        SceneManager.LoadScene("SnakeScene");
    }

    public void QuitGame()
    {
        Score.score = 0;
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
