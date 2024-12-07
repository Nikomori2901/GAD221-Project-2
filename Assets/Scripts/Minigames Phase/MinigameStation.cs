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
    
    public string teamName;
    public int morale;
    public int minigameModifier;
    public int drainAmount;
    
    public bool minigameActive;

    void Start()
    {
        team = GameObject.Find(teamName).GetComponent<Team>();
        _moraleBar = GetComponentInChildren<Slider>();
    }

    [Button]
    public void Initialize()
    {
        SetMorale(team.initialMorale);
        
        if (team.hasFunds)
        {
            minigameModifier = 2;
        }

        else
        {
            minigameModifier = 1;
        }
        
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
        StopAllCoroutines();
    }

    
    public void MoraleDepleted()
    {
        StopDraining();
        StopAllCoroutines();
        // fire event for phase manager to go to gameover screen.
    }
    #endregion
    
    #region Minigame Spawning
    public void SpawnMinigamePopup()
    {
        
    }

    public void PopupClicked()
    {
        
        minigameActive = true;
    }
    #endregion
}
