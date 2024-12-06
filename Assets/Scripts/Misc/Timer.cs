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
    
    private bool _timerActive;

    public static Action onTimerFinished;

    private void Start()
    {
        _textUI = GetComponent<TMP_Text>();
        
        EventHandler.EmployeesPhaseStart += StartTimer;
        EventHandler.EmployeesPhaseEnd += StopTimer;
        EventHandler.FundsPhaseStart += StartTimer;
        EventHandler.FundsPhaseEnd += StopTimer;
    }

    [Button]
    public void StartTimer()
    {
        Debug.Log("Start Timer");
        
        ResetTimer();
        StartCoroutine(TimerLoop());
    }

    [Button]
    public void StopTimer()
    {
        Debug.Log("Stop Timer");
        
        ResetTimer();
    }

    private void ResetTimer()
    {
        Debug.Log("Reset Timer");
        StopAllCoroutines();
        _secondsLeft = timerLength;
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

        if (_secondsLeft == 0 && onTimerFinished != null)
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