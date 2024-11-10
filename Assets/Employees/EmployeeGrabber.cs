using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeGrabber : MonoBehaviour
{
    public Employee currentEmployee;
    public bool currentlyHolding;
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
            currentEmployee.grabbed = false;
            ReturnEmployee();
        }
        
        // when released if on station that is free assigns them, if not, snaps employee back to original location
    }

    public void AssignEmployee()
    {

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

    // grabs employee when clicking on them
    
}