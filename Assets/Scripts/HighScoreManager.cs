using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private HighScoreData _highscore;

    public Text text;
    private Timer _timer;
    public SaveHighScoreToFile saveSystem;

    private void Start()
    {
        _timer = new Timer();
        _highscore = SaveHighScoreToFile.Load();
        text.text = "High Score: " + _highscore.highScore;
        GameStarted();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SaveHighScoreToFile.Save(_highscore);
        }
    }

    private void GameStarted()
    {
        _timer.StartTimer();
    }

    public void GameWon()
    {
        var timerScore = _timer.StopTimer();
        _highscore.SubmitScore(timerScore);
        text.text = "High Score: " + _highscore.highScore;
    }
}
