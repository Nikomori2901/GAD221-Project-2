using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler current;

    public Action onM1Down;
    public Action onM1Up;

    private bool lastFrameKeysDown = false;
    [SerializeField] private bool logInputs;

    void Awake()
    {
        current = this;
    }

    void Update()
    {
        // Input Down
        if (Input.anyKeyDown)
        {
            CheckInputsDown();
            CheckInputsHeld(); // If a input was pressed down this frame it automatically means that there are inputs being held.
        }

        // Input Held
        else if (Input.anyKey)
        {
            CheckInputsHeld();
        }

        // Input Up
        if (lastFrameKeysDown) // If last frame there were no keys being held then this frame there cant be any being released
        {
            CheckInputsUp();
        }

        lastFrameKeysDown = Input.anyKey;
    }

    private void CheckInputsDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DebugMessage("Input: M1 Down");
            InvokeInputAction(onM1Down);
        }
    }

    private void CheckInputsHeld()
    {

    }

    private void CheckInputsUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            DebugMessage("Input: M1 Up");
            InvokeInputAction(onM1Up);
        }
    }

    private void InvokeInputAction(Action action)
    {
        if (action != null)
        {
            action.Invoke();
        }

        else
        {
            DebugMessage("Input: No Listeners");
        }
    }

    private void DebugMessage(string message)
    {
        if (logInputs)
        {
            Debug.Log(message);
        }
    }

    // Note for self: I think improving my previous input handler template with stuff from this one and new stuff would be fun.
    // It would have:
    // Singleton Structure,
    // Toggleable Debug Messages,
    // Checks for whether type of input checks need to be done that frame,
    // Scriptable Object Events / The ability to add and hook into input events without code,
    // hotkey / key combination support,
    // Retain the ability to hook into input events via code,
    // the ability to visual see whether through unity, inspector or debug the current events and see the listeners that are attached.
}
