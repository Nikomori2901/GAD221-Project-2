using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Employee : MonoBehaviour
{
    public Collider2D collider;

    [SerializeField] public string employeeName;
    [SerializeField] public int employeeMorale;

    [SerializeField] public int designSkill;
    [SerializeField] public int programmingSkill;
    [SerializeField] public int artSkill;
    [SerializeField] public int audioSkill;

    public bool grabbed = false;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    public void Initialize(string name, int morale, int design, int programming, int art, int audio)
    {
        employeeName = name;
        employeeMorale = morale;
        designSkill = design;
        programmingSkill = programming;
        artSkill = art;
        audioSkill = audio;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Employee Hover");
        EventHandler.OnEmployeeHover(this);
    }

    private void OnMouseExit()
    {
        //Debug.Log("Unhover");
        EventHandler.OnEmployeeUnhover(this);
    }

    private void OnMouseDown()
    {
        EventHandler.OnEmployeeClick(this);
    }
}