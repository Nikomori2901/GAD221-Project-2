using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;
    private string _currentPhaseSceneName = "EmployeeAssignment";
    
    public enum GamePhases {Assignment, Work, Event}
    // Assignment Phase - Assign roster of employees to different teams based on their stats
    
    // Work Phase - Play minigames to help teams complete work and prevent teams from losing morale
    
    // Event Phase - WIP not part of prototype 1
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    public void NextPhase()
    {
        switch (_currentPhaseSceneName)
        {
            case "EmployeeAssignment":
                StartCoroutine(UnloadGamePhase("EmployeeAssignment", EventHandler.OnEmployeeAssignmentEnd));
                // If there's issues might have to make load wait for unload to finish
                StartCoroutine(LoadGamePhase("WorkDay", EventHandler.OnWorkdayStart));
                break;
            case "WorkDay":
                //LoadGamePhase("WorkDay");
                break;
            default:
                break;
        }
    }
    
    public IEnumerator LoadGamePhase(string sceneName, Action startEvent)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        
        yield return new WaitForSeconds(0.05f);

        startEvent();
    }
    
    public IEnumerator UnloadGamePhase(string sceneName, Action stopEvent)
    {
        stopEvent();
        
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.UnloadSceneAsync(sceneName);
    }
}