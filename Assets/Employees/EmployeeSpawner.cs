using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmployeeSpawner : MonoBehaviour
{
    public static EmployeeSpawner instance;
    
    public TMP_Text employeesLeftText;
    
    public List<Employee> employees = new List<Employee>();
    public GameObject employeePrefab;
    public Vector3 spawnLocation;
    public int initialRosterSize;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EventHandler.EmployeeAssigned += RemoveEmployee;
        
        GenerateInitialRoster();
        NextEmployee();
    }
    
    private void GenerateInitialRoster()
    {
        for (int i = 0; i < initialRosterSize; i++)
        {
            NewEmployee();
        }
    }
    
    public void NewEmployee()
    {
        Employee newEmployee = Instantiate(employeePrefab, spawnLocation, Quaternion.identity).GetComponent<Employee>();
        newEmployee.Initialize(RandomName(), 100,Random.Range(1, 6),Random.Range(1, 6),Random.Range(1, 6),Random.Range(1, 6));
        newEmployee.gameObject.SetActive(false);
        employees.Add(newEmployee);
    }

    public void RemoveEmployee(Employee employee)
    {
        employees.Remove(employee);
    }

    public void NextEmployee()
    {
        UpdateEmployeesLeftText();
        
        if (employees.Count > 0)
        {
            employees[Random.Range(0, employees.Count)].gameObject.SetActive(true);
        }

        else
        {
            EndAssignmentPhase();
        }
    }

    private void EndAssignmentPhase()
    {
        Debug.Log("EndAssignmentPhase");
        // go to next phase of game
        // should probably go in phase manager
    }

    private string RandomName()
    {
        return "Employee";
        // low priority will add later
    }

    private void UpdateEmployeesLeftText()
    {
        employeesLeftText.text = "Employees Left: " + employees.Count.ToString();
    }
}