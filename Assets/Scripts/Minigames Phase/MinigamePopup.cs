using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VInspector;

public class MinigamePopup : MonoBehaviour
{
    public MinigameStation station;
    public Button button;

    public AudioSource audioSource;
    

    private void Start()
    {
        button = GetComponent<Button>();
        
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
        //clickable = !clickable;
        button.interactable = !button.interactable;
    }

    public void OnMouseDown()
    {
        audioSource.Play();
        EventHandler.OnToggleMinigame();
        station.PopupClicked();
        gameObject.SetActive(false);
    }
}