using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beep : MonoBehaviour
{
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        EventHandler.BeepNoise += PlaySound;
    }

    private void OnDestroy()
    {
        EventHandler.BeepNoise -= PlaySound;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
