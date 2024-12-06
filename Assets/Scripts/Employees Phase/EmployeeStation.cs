using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeStation : MonoBehaviour
{
    private Team _team;
    
    public string teamName;

    private void Start()
    {
        _team = GameObject.Find(teamName).GetComponent<Team>();
    }

    public void AssignEmployee(Employee employee)
    {
        _team.assignedEmployees.Add(employee);
    }
}
