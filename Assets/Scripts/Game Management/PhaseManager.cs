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

    private int _stageNumber = 1;

    public static event Action UnloadPhase;
    
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
    
    public IEnumerator LoadGamePhase(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        
        yield return new WaitForSeconds(0.05f);
    }
    
    public IEnumerator UnloadGamePhase(string sceneName, Action stopEvent)
    {
        stopEvent();
        UnloadPhase?.Invoke();
        
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.UnloadSceneAsync(sceneName);
    }
    
    public IEnumerator UnloadGamePhase(string sceneName)
    {
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void ResetStage()
    {
        _stageNumber = 1;
    }

    public void NextStage()
    {
        if (_stageNumber < 5)
        {
            _stageNumber++;
        }

        else
        {
            // Game Complete
        }
    }

    [Button]
    public void MainMenu()
    {
        StartCoroutine(UnloadGamePhase(_currentGamePhase.ToString() + "Scene"));
        StartCoroutine(LoadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseStart));
        _currentGamePhase = GamePhase.MainMenu;
    }

    [Button]
    public void GameOver()
    {
        StartCoroutine(UnloadGamePhase(_currentGamePhase.ToString() + "Scene"));
        StartCoroutine(LoadGamePhase("GameOverScene", EventHandler.OnGameOverPhaseStart));
        _currentGamePhase = GamePhase.GameOver;
    }

    public int GetStageNumber()
    {
        return _stageNumber;
    }
}