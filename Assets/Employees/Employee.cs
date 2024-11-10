using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Employee : MonoBehaviour
{
    [SerializeField] public string employeeName;
    [SerializeField] public int employeeMorale;

    [SerializeField] public int designSkill;
    [SerializeField] public int programmingSkill;
    [SerializeField] public int artSkill;
    [SerializeField] public int audioSkill;

    [SerializeField] UnityEvent<GameObject> showTooltip;
    [SerializeField] UnityEvent<GameObject> hideTooltip;
    [SerializeField] UnityEvent<Employee> onMouseDown;

    public bool grabbed = false;

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
        Debug.Log("Hover");
        showTooltip.Invoke(gameObject);
    }

    private void OnMouseExit()
    {
        Debug.Log("Unhover");
        if (!grabbed)
        {
            hideTooltip.Invoke(gameObject);
        }
    }

    private void OnMouseDown()
    {
        grabbed = true;
        onMouseDown.Invoke(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}