using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RandomTableAssist : MonoBehaviour
{
    public int randomNum;
    public int currentMiniGameAmount;
    public int maxMiniGameAmount;
    public int minMiniGameAmount = 0;
    public UnityEngine.UI.Button programmingButton;
    public UnityEngine.UI.Button gameButton;
    public UnityEngine.UI.Button artButton;
    public UnityEngine.UI.Button audioButton;
    public GameObject programmingAssistImage;
    public GameObject gameAssistImage;
    public GameObject artAssistImage;
    public GameObject audioAssistImage;
    public bool isGenerating;

    // Start is called before the first frame update
    void Start()
    {
        currentMiniGameAmount = minMiniGameAmount;
        isGenerating = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerating == true)
        {
            randomGenerator();
        }
        

        if (randomNum == 1)
        {
            programmingButton.enabled = true;
            programmingAssistImage.SetActive(true);
            currentMiniGameAmount += 1;
        }
        else
        {
            programmingButton.enabled = false;
            programmingAssistImage.SetActive(false);
        }

        if (randomNum == 2)
        {
            gameButton.enabled = true;
            gameAssistImage.SetActive(true);
            currentMiniGameAmount += 1;
        }
        else
        {
            gameButton.interactable= false;
            gameAssistImage.SetActive(false);
        }

        if (randomNum == 3)
        {
            artButton.enabled = true;
            artAssistImage.SetActive(true);
            currentMiniGameAmount += 1;
        }
        else
        {
            artButton.interactable = false;
            artAssistImage.SetActive(false);
        }

        if (randomNum == 4)
        {
            audioButton.interactable = true;
            audioAssistImage.SetActive(true);
            currentMiniGameAmount += 1;
        }
        else
        {
            audioButton.interactable = false;
            audioAssistImage.SetActive(false);
        }

        if (currentMiniGameAmount == maxMiniGameAmount)
        {
            isGenerating = false;
        }

    }

    void randomGenerator()
    {
        randomNum = Random.Range(1, 4);
    }

}
