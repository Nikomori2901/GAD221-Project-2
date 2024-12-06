using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;
    
    public enum GamePhase {Email, Employees, Funds, Minigames, GameOver, MainMenu}

    private GamePhase _currentGamePhase;
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        // Set Inital Phase to Email Phase
        _currentGamePhase = GamePhase.MainMenu;
        StartCoroutine(LoadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseStart));
        
        Timer.onTimerFinished += NextPhase;
    }
    
    [Button]
    public void NextPhase() // Unload the Current Phase & Load the next one
    {
        Debug.Log("NextPhase");
        
        switch (_currentGamePhase)
        {
            case GamePhase.Email:
                StartCoroutine(UnloadGamePhase("EmailScene", EventHandler.OnEmailPhaseEnd));
                StartCoroutine(LoadGamePhase("EmployeesScene", EventHandler.OnEmployeesPhaseStart));
                _currentGamePhase = GamePhase.Employees;
            break;
            
            case GamePhase.Employees:
                StartCoroutine(UnloadGamePhase("EmployeesScene", EventHandler.OnEmployeesPhaseEnd));
                StartCoroutine(LoadGamePhase("FundsScene", EventHandler.OnFundsPhaseStart));
                _currentGamePhase = GamePhase.Funds;
            break;
            
            case GamePhase.Funds:
                StartCoroutine(UnloadGamePhase("FundsScene", EventHandler.OnFundsPhaseEnd));
                StartCoroutine(LoadGamePhase("MinigamesScene", EventHandler.OnMinigamesPhaseStart));
                _currentGamePhase = GamePhase.Minigames;
            break;
            
            case GamePhase.Minigames:
                StartCoroutine(UnloadGamePhase("MinigamesScene", EventHandler.OnMinigamesPhaseEnd));
                StartCoroutine(LoadGamePhase("EmailScene", EventHandler.OnEmailPhaseStart));
                _currentGamePhase = GamePhase.Email;
            break;
            
            case GamePhase.MainMenu:
                StartCoroutine(UnloadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseEnd));
                StartCoroutine(LoadGamePhase("EmailScene", EventHandler.OnEmailPhaseStart));
                _currentGamePhase = GamePhase.Email;
                break;
            
            case GamePhase.GameOver:
                StartCoroutine(UnloadGamePhase("GameOverScene", EventHandler.OnGameOverPhaseEnd));
                StartCoroutine(LoadGamePhase("EmailScene", EventHandler.OnEmailPhaseStart));
                _currentGamePhase = GamePhase.Email;
                break;
        }
    }
    
    public IEnumerator LoadGamePhase(string sceneName, Action startEvent)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        
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