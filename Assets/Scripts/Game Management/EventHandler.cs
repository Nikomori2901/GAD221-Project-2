using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<Employee> EmployeeHovered;
    public static event Action<Employee> EmployeeUnhovered;
    public static event Action<Employee> EmployeeClicked;
    public static event Action<Employee> EmployeeAssigned;
    
    public static event Action<FundPile> FundPileHovered;
    public static event Action<FundPile> FundPileUnhovered;
    public static event Action<FundPile> FundPileClicked;
    public static event Action<FundPile> FundPileAssigned;
    
    // Phase Events
    public static event Action EmailPhaseStart;
    public static event Action EmailPhaseEnd;
    
    public static event Action EmployeesPhaseStart;
    public static event Action EmployeesPhaseEnd;
    
    public static event Action FundsPhaseStart;
    public static event Action FundsPhaseEnd;
    
    public static event Action MinigamesPhaseStart;
    public static event Action MinigamesPhaseEnd;
        
    public static void OnEmployeeHover(Employee employee)
    {
        Debug.Log("OnEmployeeHover");

        EmployeeHovered?.Invoke(employee);
    }

    public static void OnEmployeeUnhover(Employee employee)
    {
        EmployeeUnhovered?.Invoke(employee);
    }

    public static void OnEmployeeClick(Employee employee)
    {
        EmployeeClicked?.Invoke(employee);
    }

    public static void OnEmployeeAssigned(Employee employee)
    {
        EmployeeAssigned?.Invoke(employee);
    }

    public static void OnFundPileHover(FundPile fundPile)
    {
        FundPileHovered?.Invoke(fundPile);
    }
    
    public static void OnFundPileUnhover(FundPile fundPile)
    {
        FundPileUnhovered?.Invoke(fundPile);
    }
    
    public static void OnFundPileClicked(FundPile fundPile)
    {
        FundPileClicked?.Invoke(fundPile);
    }

    public static void OnFundPileAssigned(FundPile fundPile)
    {
        FundPileAssigned?.Invoke(fundPile);
    }

    // Phase Event Invocators
    public static void OnEmailPhaseStart()
    {
        EmailPhaseStart?.Invoke();
    }
    
    public static void OnEmailPhaseEnd()
    {
        EmailPhaseEnd?.Invoke();
    }
    
    public static void OnEmployeesPhaseStart()
    {
        Debug.Log("OnEmployeeAssignmentStart");
        EmployeesPhaseStart?.Invoke();
    }
    
    public static void OnEmployeesPhaseEnd()
    {
        EmployeesPhaseEnd?.Invoke();
    }

    public static void OnFundsPhaseStart()
    {
        FundsPhaseStart?.Invoke();
    }
    
    public static void OnFundsPhaseEnd()
    {
        FundsPhaseEnd?.Invoke();
    }
    
    public static void OnMinigamesPhaseStart()
    {
        MinigamesPhaseStart?.Invoke();
    }
    
    public static void OnMinigamesPhaseEnd()
    {
        MinigamesPhaseEnd?.Invoke();
    }
}