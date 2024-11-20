using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMinigameButtons : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClick(GameObject button)
    {
        audioSource.Play();
        button.SetActive(false);
    }
}
