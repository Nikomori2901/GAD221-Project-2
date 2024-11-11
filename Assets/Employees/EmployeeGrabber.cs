using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeGrabber : MonoBehaviour
{
    public Employee currentEmployee;
    public bool currentlyHolding;
    public TeamStation hoveringStation;

    private Vector3 employeeOriginalPos;

    void Start()
    {
        InputHandler.current.onM1Up += ReleaseEmployee;
    }

    void Update()
    {
        
    }

    public void GrabEmployee(Employee employee)
    {
        if (!currentlyHolding)
        {
            currentEmployee = employee;
            currentEmployee.collider.enabled = false;
            currentlyHolding = true;
            employeeOriginalPos = employee.transform.position;
            StartCoroutine(Holding());
        }
    }

    private IEnumerator Holding()
    {
        while (currentlyHolding)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currentEmployee.transform.position.z));
            currentEmployee.transform.position = new Vector3 (mousePos.x, mousePos.y, currentEmployee.transform.position.z);

            yield return new WaitForFixedUpdate();
        }
    }

    public void ReleaseEmployee()
    {
        if (currentlyHolding)
        {
            if (hoveringStation != null)
            {
                AssignEmployee();
            }

            else
            {
                currentEmployee.collider.enabled = true;
                ReturnEmployee();
            }
        }
    }

    // The two hover functions would probably be better off as a raycast but this is a simple solution for prototyping.
    public void HoverStation(TeamStation station)
    {
        hoveringStation = station;
    }

    public void UnhoverStation()
    {
        hoveringStation = null;
    }

    public void AssignEmployee()
    {
        currentEmployee.gameObject.SetActive(false);
        hoveringStation.AddEmployee(currentEmployee);
    }

    public void ReturnEmployee()
    {
        currentEmployee.transform.position = employeeOriginalPos;
        ClearEmployee();
    }

    private void ClearEmployee()
    {
        currentEmployee = null;
        currentlyHolding = false;
        employeeOriginalPos = Vector3.zero;
        StopAllCoroutines();
    }
}