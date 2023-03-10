using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fiel

    private float totalSeconds = 0;
    private float elapsedSeconds = 0;
    private bool running = false;
    private bool started = false;

    #endregion

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }
    public void Run()
    {
        if(totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    public bool Finished
    {
        get => started && !running;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if(elapsedSeconds > totalSeconds) { running = false; }
        }
    }
}
