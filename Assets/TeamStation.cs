using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStation : MonoBehaviour
{
    public List<Employee> employees = new List<Employee>();

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
