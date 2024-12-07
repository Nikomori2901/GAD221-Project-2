using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class Team : MonoBehaviour
{
    public enum TeamType {Design, Programming, Art, Audio}
    public TeamType teamType;
    
    public List<Employee> assignedEmployees = new List<Employee>(); // Assigned during assignment phase
    
    public int totalSkill; // Affects initial morale & minigame modifier
    public bool hasFunds; // Affects minigameModifier
    public int initialMorale;
    
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
    
    [Button]
    public void SetInitialMorale()
    {
        int totalSkill = CalculateTotalSkill();
        
        if (totalSkill > 8)
        {
            initialMorale = 100;
        }
        
        else if (totalSkill > 6)
        {
            initialMorale = 90;
        }
        
        else if (totalSkill > 4)
        {
            initialMorale = 80;
        }
        
        else if (totalSkill > 2)
        {
            initialMorale = 70;
        }

        else
        {
            initialMorale = 50;
        }
    }
}
