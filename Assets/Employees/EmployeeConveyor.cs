using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeConveyor : MonoBehaviour
{
    public List<Employee> employees = new List<Employee>();
    public GameObject employeePrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateInitialRoster()
    {

    }

    public void NextEmployee()
    {
        // select random remaining employee
        // position it and make it visible
    }

    public void EmptyRoster()
    {

    }

    // generate random employees on game start
    // offers random employees from roster until empty
    // once done or timer runs out do processes then go to next gamephase
}