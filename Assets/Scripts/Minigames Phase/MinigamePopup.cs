using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigamePopup : MonoBehaviour
{
    public MinigameStation station;
    
    public void OnMouseDown()
    {
        station.PopupClicked();
        gameObject.SetActive(false);
    }
}