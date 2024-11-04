using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hoverable : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> OnHoverEvent;
    [SerializeField] UnityEvent<GameObject> OnUnhoverEvent;

    private void OnMouseEnter()
    {
        Debug.Log("Hover");
        OnHoverEvent.Invoke(gameObject);
    }

    private void OnMouseExit()
    {
        Debug.Log("Unhover");
        OnUnhoverEvent.Invoke(gameObject);
    }
}