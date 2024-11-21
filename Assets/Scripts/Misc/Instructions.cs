using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public float displayTime;
    
    void Start()
    {
        StartCoroutine(DelayedDisable(displayTime));
    }

    private IEnumerator DelayedDisable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
