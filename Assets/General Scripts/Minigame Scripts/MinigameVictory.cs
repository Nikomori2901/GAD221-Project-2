using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class MinigameVictory : MonoBehaviour
{
    public static MinigameVictory instance;
    
    private AudioSource audioSource;
    
    void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    [Button]
    public void SuccessSFX()
    {
        audioSource.Play();
    }
}
