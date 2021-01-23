using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 1f;


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<SpawnFood>().CancelInvoke("Spawn");
            Debug.Log("GAME OVER");
            Invoke("Quit", restartDelay);
        }
        
    }

    void Quit ()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void Restart ()
    {
        SceneManager.LoadScene("SnakeScene");
    }
}