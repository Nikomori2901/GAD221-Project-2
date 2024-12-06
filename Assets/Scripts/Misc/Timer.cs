using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using VInspector;

public class Timer : MonoBehaviour
{
    private TMP_Text _textUI;

    public int timerLength;
    private int _secondsLeft;

    public static Action onTimerFinished;

    private void Start()
    {
        _textUI = GetComponent<TMP_Text>();
        
        EventHandler.EmployeesPhaseStart += StartTimer;
    }

    [Button]
    public void StartTimer()
    {
        Debug.Log("Start Timer");
        _secondsLeft = timerLength;
        StartCoroutine(TimerLoop());
    }

    [Button]
    public void StopTimer()
    {
        Debug.Log("Stop Timer");
        StopAllCoroutines();
        if (onTimerFinished != null)
        {
            onTimerFinished();
        }
    }

    private IEnumerator TimerLoop()
    {
        while (_secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);

            _secondsLeft--;
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
        Debug.Log(_secondsLeft);
        _textUI.text = "Time Left: " + _secondsLeft.ToString();
    }
}