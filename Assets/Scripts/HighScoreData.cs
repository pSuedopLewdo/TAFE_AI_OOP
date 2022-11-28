using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public HighScoreData()
    {
        highScore = float.MaxValue;
    }

    public HighScoreData(float prevScore)
    {
        highScore = prevScore;
    }
    public void SubmitScore(float newScore)
    {
        if (highScore > newScore)
        {
            highScore = newScore;
        }
    }
    public float highScore;
}
