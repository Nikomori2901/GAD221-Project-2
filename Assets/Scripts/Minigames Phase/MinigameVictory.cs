using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class MinigameVictory : MonoBehaviour
{
    public static MinigameVictory instance;
    
    public AudioSource audioSource;
    
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    [Button]
    public static void SuccessSFX()
    {
        Debug.Log("SuccessSFX");
        instance.audioSource.Play();
    }
}
