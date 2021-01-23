using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreWindow : MonoBehaviour
{
    //public Transform Snake;
    public Text scoreText;

    private void Awake()
    {
        scoreText.text = "0";
    }


    void Update()
    {
        scoreText.text = Score.GetScore().ToString();
    }
}