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
        gameObject.SetActive(true);
    }
    
    public void ShowTooltip<T>(T eventArgs)
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
    
    public void HideTooltip<T>(T eventArgs)
    {
        gameObject.SetActive(false);
    }
}