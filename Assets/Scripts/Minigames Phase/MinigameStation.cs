using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VInspector;

public class MinigameStation : MonoBehaviour
{
    public Team team;
    private Slider _moraleBar;
    public Minigame minigame;
    public MinigamePopup minigamePopup;
    
    public string teamName;
    public int morale;
    public int minigameModifier;
    public int drainAmount;
    
    public bool minigameActive;

    void Start()
    {
        team = GameObject.Find(teamName).GetComponent<Team>();
        _moraleBar = GetComponentInChildren<Slider>();
        
        EventHandler.MinigamesPhaseStart += Initialize;
    }

    [Button]
    public void Initialize()
    {
        Debug.Log("Initialize");
        SetMorale(team.initialMorale);
        
        if (team.hasFunds)
        {
            minigameModifier = 2;
        }

        else
        {
            minigameModifier = 1;
        }
        
        StartSpawning();
        StartDraining();
    }
    
    #region Morale

    public void SetMorale(int moraleValue)
    {
        morale = moraleValue;
        _moraleBar.value = morale;
    }
    [Button]
    public void StartDraining()
    {
        StartCoroutine(DrainMorale());
    }

    public IEnumerator DrainMorale()
    {
        while (morale > 0)
        {
            if (!minigameActive)
            {
                SetMorale(morale - drainAmount);
            }
            
            yield return new WaitForSeconds(1);
        }
        
        MoraleDepleted();
    }

    [Button]
    public void StopDraining()
    {
        StopCoroutine("DrainMorale");
    }

    
    public void MoraleDepleted()
    {
        StopDraining();
        StopAllCoroutines();
        // fire event for phase manager to go to gameover screen.
    }
    #endregion
    
    #region Minigame Spawning

    public void StartSpawning()
    {
        Debug.Log("StartSpawning");
        int seconds = Random.Range(5, 15);
        StartCoroutine(Spawning(seconds));
    }

    public IEnumerator Spawning(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnMinigamePopup();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawning");
    }
    
    public void SpawnMinigamePopup()
    {
        minigamePopup.gameObject.SetActive(true);
    }

    public void PopupClicked()
    {
        minigame.StartMinigame(this);
        minigameActive = true;
        StopSpawning();
    }
    #endregion
}
