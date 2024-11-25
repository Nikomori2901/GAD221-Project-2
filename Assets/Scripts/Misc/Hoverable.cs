using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hoverable : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> onHoverEvent;
    [SerializeField] UnityEvent<GameObject> onUnhoverEvent;
    private void OnMouseEnter()
    {
        Debug.Log("Hover");
        onHoverEvent.Invoke(gameObject);
    }

    private void OnMouseExit()
    {
        Debug.Log("Unhover");
        onUnhoverEvent.Invoke(gameObject);
    }
}