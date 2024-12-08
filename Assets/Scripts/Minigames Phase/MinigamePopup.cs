using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigamePopup : MonoBehaviour
{
    public MinigameStation station;
    
    public bool clickable = true;

    private void Start()
    {
        EventHandler.ToggleMinigame += ToggleClickable;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventHandler.ToggleMinigame -= ToggleClickable;
    }

    public void ToggleClickable()
    {
        Debug.Log("ToggleClickable");
        clickable = !clickable;
    }

    public void OnMouseDown()
    {
        if (clickable)
        {
            EventHandler.OnToggleMinigame();
            station.PopupClicked();
            gameObject.SetActive(false);
        }
    }
}