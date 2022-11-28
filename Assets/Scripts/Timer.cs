using UnityEngine;

public class Timer
{
    public float startTime{get; private set; }

    public void StartTimer()
    {
        startTime = -1f;
        startTime = Time.time;
    }

    public float StopTimer()
    {
        var score = Time.time - startTime;
        startTime = -1f;
        return score;
    }
}
