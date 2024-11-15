using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeTooltip : Tooltip
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text moraleText;
    [SerializeField] TMP_Text designText;
    [SerializeField] TMP_Text programmingText;
    [SerializeField] TMP_Text artText;
    [SerializeField] TMP_Text audioText;


    void Start()
    {
        EventHandler.EmployeeHovered += SetEmployeeInfo;
        EventHandler.EmployeeHovered += ShowTooltip;
        EventHandler.EmployeeUnhovered += HideTooltip;
        
        gameObject.SetActive(false);
    }
    
    public void SetEmployeeInfo(Employee employee)
    {
        Debug.Log("SetEmployeeInfo");
        nameText.text = employee.employeeName;
        moraleText.text = "Morale: " + employee.employeeMorale;
        designText.text = "Design: " + employee.designSkill;
        programmingText.text = "Programming: " + employee.programmingSkill;
        artText.text = "Art: " + employee.artSkill;
        audioText.text = "Audio: " + employee.audioSkill;
    }
}