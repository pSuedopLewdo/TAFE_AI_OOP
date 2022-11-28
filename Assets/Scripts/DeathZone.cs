using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : Zone
{
    [SerializeField] protected Text dedText;
    protected static List<GameObject> ded;

    private void Start()
    {
        if (ded == null)
        {
            ded = new List<GameObject>();
        }
        dedText.text = "";
    }
    
    // need this because the Zone class is Abstract
    protected override void ZoneTrigger(GameObject marble)
    {
        if (!ded.Contains(marble))
        {
            ded.Add(marble);
        }
        marble.SetActive(false);
        ded.Add(marble);
        DisplayDedText(marble.name);
    }
    protected void DisplayDedText(string marbleName)
    {
        dedText.text += marbleName + '\n';
    }
}
