using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VInspector;

public class Timer : MonoBehaviour
{
    TMP_Text textUI;

    public float secondsLeft;

    public static Action onTimerFinished;

    void Start()
    {
        textUI = GetComponent<TMP_Text>();
    }

    [Button]
    public void StartTimer()
    {
        Debug.Log("Start Timer");
        StartCoroutine(TimerLoop());
    }

    [Button]
    public void StopTimer()
    {
        Debug.Log("Stop Timer");
        StopAllCoroutines();
    }

    private IEnumerator TimerLoop()
    {
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);

            secondsLeft--;
            UpdateTimerText();
        }

        Debug.Log("Timer Finished");

        if (onTimerFinished != null)
        {
            onTimerFinished();
        }
    }

    private void UpdateTimerText()
    {
        Debug.Log(secondsLeft);
        textUI.text = "Time Left: " + secondsLeft.ToString();
    }
}
