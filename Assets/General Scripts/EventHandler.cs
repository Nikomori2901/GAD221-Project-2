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
    public static event Action EmployeeAssignmentStart;
    public static event Action EmployeeAssignmentEnd;
    public static event Action WorkDayStart;

    public static event Action WorkDayEnd;
        
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

    public static void OnEmployeeAssignmentStart()
    {
        EmployeeAssignmentStart?.Invoke();
    }
    
    public static void OnEmployeeAssignmentEnd()
    {
        EmployeeAssignmentEnd?.Invoke();
    }
    
    public static void OnWorkdayStart()
    {
        WorkDayStart?.Invoke();
    }
    
    public static void OnWorkdayEnd()
    {
        WorkDayEnd?.Invoke();
    }
}