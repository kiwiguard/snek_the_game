using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public static int score; //stores current score


    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 1;
    }
}
