using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    [SerializeField] public string employeeName;
    [SerializeField] public int employeeMorale;

    [SerializeField] public int designSkill;
    [SerializeField] public int programmingSkill;
    [SerializeField] public int artSkill;
    [SerializeField] public int audioSkill;

    public void Initialize(string name, int morale, int design, int programming, int art, int audio)
    {
        employeeName = name;
        employeeMorale = morale;
        designSkill = design;
        programmingSkill = programming;
        artSkill = art;
        audioSkill = audio;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
