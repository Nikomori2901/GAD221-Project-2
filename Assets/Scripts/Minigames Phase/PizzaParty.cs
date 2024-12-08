using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaParty : MonoBehaviour
{
    // 4 sprites
    // counter
    // counter increment on minigame complete
    // max 4
    // clickable
    // pauses timer
    
    public List<MinigameStation> minigameStations = new List<MinigameStation>();

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    public int count;

    public Button button;
    
    void Start()
    {
        EventHandler.MinigameComplete += IncrementCount;
        
        count = 0;
        button.interactable = false;
        
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        SetColorNormal();
        
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventHandler.MinigameComplete -= IncrementCount;
    }

    public void IncrementCount()
    {
        count++;

        switch (count)
        {
            case 1:
                image1.gameObject.SetActive(true);
                break;
            case 2:
                image2.gameObject.SetActive(true);
                break;
            case 3:
                image3.gameObject.SetActive(true);
                break;
            case 4:
                image4.gameObject.SetActive(true);
                EnableButton();
                break;
            
            default:
                // do nothing
                break;
        }
    }

    public void EnableButton()
    {
        button.interactable = true;
    }

    public void ButtonPressed()
    {
        StartCoroutine(DrainPause());
        button.interactable = false;
    }

    public IEnumerator DrainPause()
    {
        StartDrainPause();

        yield return new WaitForSeconds(25 - (PhaseManager.instance.stageNumber * 5));
        
        StopDrainPause();
    }
    
    public void StartDrainPause()
    {
        SetColorGreen();
        
        foreach (MinigameStation station in minigameStations)
        {
            station.drainAmount = 0;
        }
    }

    public void StopDrainPause()
    {
        SetColorNormal();
        
        foreach (MinigameStation station in minigameStations)
        {
            station.drainAmount = station.initalDrainAmount;
        }
        
        Used();
    }

    public void SetColorNormal()
    {
        image1.color = Color.white;
        image2.color = Color.white;
        image3.color = Color.white;
        image4.color = Color.white;
    }

    public void SetColorGreen()
    {
        image1.color = Color.green;
        image2.color = Color.green;
        image3.color = Color.green;
        image4.color = Color.green;
    }

    public void Used()
    {
        count = 0;
        button.interactable = false;
        
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        SetColorNormal();
        
        gameObject.SetActive(false);
    }
}