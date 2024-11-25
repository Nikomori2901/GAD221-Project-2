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
        moraleText.text = "Morale\n" + employee.employeeMorale.ToString();
        designText.text = employee.designSkill.ToString();
        programmingText.text = employee.programmingSkill.ToString();
        artText.text = employee.artSkill.ToString();
        audioText.text = employee.audioSkill.ToString();
    }
}