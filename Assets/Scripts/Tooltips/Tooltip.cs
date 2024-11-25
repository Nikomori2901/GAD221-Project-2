using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void ShowTooltip()
    {
        Debug.Log("ShowTooltip");
        gameObject.SetActive(true);
    }
    
    public void ShowTooltip<T>(T eventArgs)
    {
        Debug.Log("ShowTooltip");
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        Debug.Log("HideTooltip");
        gameObject.SetActive(false);
    }
    
    public void HideTooltip<T>(T eventArgs)
    {
        Debug.Log("HideTooltip");
        gameObject.SetActive(false);
    }
}