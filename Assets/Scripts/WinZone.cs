using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : Zone
{
    public HighScoreManager highScore;
    [SerializeField] protected Text winnerText;
    protected static List<GameObject> winners;

    private void Start()
    {
        if (winners == null)
        {
            winners = new List<GameObject>();
        }
        winnerText.text = "";
    }

    protected void DisplayWinText(string marbleName)
    {
        winnerText.text += marbleName + '\n';
    }

    // need this because the Zone class is Abstract
    protected override void ZoneTrigger(GameObject marble)
    {
        if (winners.Contains(marble)) return;
        
        winners.Add(marble);
        DisplayWinText(marble.name);
        StartCoroutine(DisableWithDelay(marble, 3));

        if (highScore == null)
        {
            highScore = FindObjectOfType<HighScoreManager>();
        }
        highScore.GameWon();
    }
}
