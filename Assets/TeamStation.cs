using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStation : MonoBehaviour
{
    public List<Employee> employees = new List<Employee>();
    private int _workload;
    private int _teamMorale;

    // morale is the combined morale of the employees in the team
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void RemoveEmployee()
    {

    }
}
