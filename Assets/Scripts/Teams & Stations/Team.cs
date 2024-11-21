using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class Team : MonoBehaviour
{
    //public Slider slider;
    
    public enum TeamType {Design, Programming, Art, Audio}
    public TeamType teamType;
    
    public List<Employee> assignedEmployees = new List<Employee>(); // Assigned during assignment phase
    public int totalSkill; // Affects initial morale & minigame modifier
    
    public bool hasFunds; // Affects minigameModifier
    
    public bool minigameActive; // Affects morale drain rate 
    
    public int morale; // Starts at an initial amount then drains, raised by succesful minigame completion
    public int drainSpeed; // Speed at which morale drains, not really a good barometer
    public int drainSpeedFast;

    public int minigameModifier; // Given to minigame when spawned
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Reset()
    {
        assignedEmployees.Clear();
        totalSkill = 0;
        hasFunds = false;
        minigameActive = false;
        morale = 0;
        minigameModifier = 0;
    }
    
    public int CalculateTotalSkill()
    {
        switch (teamType)
        {
            case TeamType.Programming:
                foreach (Employee employee in assignedEmployees)
                {
                    totalSkill += employee.programmingSkill;
                }
                break;
            
            case TeamType.Art:
                foreach (Employee employee in assignedEmployees)
                {
                    totalSkill += employee.artSkill;
                }
                break;
            
            case TeamType.Audio:
                foreach (Employee employee in assignedEmployees)
                {
                    totalSkill += employee.audioSkill;
                }
                break;
            
            case TeamType.Design:
                foreach (Employee employee in assignedEmployees)
                {
                    totalSkill += employee.designSkill;
                }
                break;
        }
        
        return totalSkill;
    }

    public void SetInitialMorale()
    {
        if (totalSkill > 8)
        {
            morale = 100;
        }
        
        else if (totalSkill > 6)
        {
            morale = 90;
        }
        
        else if (totalSkill > 4)
        {
            morale = 80;
        }
        
        else if (totalSkill > 2)
        {
            morale = 70;
        }

        else
        {
            morale = 50;
        }
    }

    [Button]
    public void StartDraining()
    {
        StartCoroutine(DrainMorale());
    }

    public IEnumerator DrainMorale()
    {
        if (minigameActive)
        {
            morale -= drainSpeedFast;
        }

        else
        {
            morale -= drainSpeed;
        }
        
        // update slider on minigameStation

        if (morale <= 0)
        {
            MoraleDepleted();
        }

        yield return new WaitForSeconds(1);
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
    
    public void SpawnMinigame()
    {
        // providing the modifiers for the minigame and spawning it.
    }
}
