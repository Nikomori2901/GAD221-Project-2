using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using VInspector;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;

    public Timer timer;
    
    public enum GamePhase {Email, Employees, Funds, Minigames, GameOver, MainMenu, Win}

    private GamePhase _currentGamePhase;

    public int stageNumber = 1;

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

    void OnDestroy()
    {
        Timer.onTimerFinished -= NextPhase;
    }
    
    [Button]
    public void NextPhase() // Unload the Current Phase & Load the next one
    {
        Debug.Log("NextPhase");
        
        switch (_currentGamePhase)
        {
            case GamePhase.Email:
                StartCoroutine(UnloadGamePhase("EmailScene", EventHandler.OnEmailPhaseEnd));
                timer.timerLength = 20;
                StartCoroutine(LoadGamePhase("EmployeesScene", EventHandler.OnEmployeesPhaseStart));
                _currentGamePhase = GamePhase.Employees;
            break;
            
            case GamePhase.Employees:
                StartCoroutine(UnloadGamePhase("EmployeesScene", EventHandler.OnEmployeesPhaseEnd));
                timer.timerLength = 20;
                StartCoroutine(LoadGamePhase("FundsScene", EventHandler.OnFundsPhaseStart));
                _currentGamePhase = GamePhase.Funds;
            break;
            
            case GamePhase.Funds:
                StartCoroutine(UnloadGamePhase("FundsScene", EventHandler.OnFundsPhaseEnd));
                timer.timerLength = 60;
                StartCoroutine(LoadGamePhase("MinigamesScene", EventHandler.OnMinigamesPhaseStart));
                _currentGamePhase = GamePhase.Minigames;
            break;
            
            case GamePhase.Minigames:
                StartCoroutine(UnloadGamePhase("MinigamesScene", EventHandler.OnMinigamesPhaseEnd));
                
                if (stageNumber < 4)
                {
                    stageNumber++;
                    StartCoroutine(LoadGamePhase("EmailScene", EventHandler.OnEmailPhaseStart));
                    _currentGamePhase = GamePhase.Email;
                }

                else
                {
                    WinScreen();
                }
            break;
            
            case GamePhase.MainMenu:
                StartCoroutine(UnloadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseEnd));
                StartCoroutine(LoadGamePhase("EmailScene", EventHandler.OnEmailPhaseStart));
                _currentGamePhase = GamePhase.Email;
                break;
            
            case GamePhase.GameOver:
                StartCoroutine(UnloadGamePhase("GameOverScene", EventHandler.OnGameOverPhaseEnd));
                StartCoroutine(LoadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseStart));
                ResetStage();
                _currentGamePhase = GamePhase.MainMenu;
                break;
            
            case GamePhase.Win:
                StartCoroutine(UnloadGamePhase("WinScene"));
                StartCoroutine(LoadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseStart));
                ResetStage();
                _currentGamePhase = GamePhase.MainMenu;
                break;
        }
    }
    
    public IEnumerator LoadGamePhase(string sceneName, Action startEvent)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        
        yield return new WaitForSeconds(0.05f);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        
        yield return new WaitForSeconds(0.05f);
        
        //Debug.Log("Load Event");
        startEvent?.Invoke();
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
        stopEvent?.Invoke();
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
        stageNumber = 1;
    }

    [Button]
    public void MainMenu()
    {
        StartCoroutine(UnloadGamePhase(_currentGamePhase.ToString() + "Scene"));
        StartCoroutine(LoadGamePhase("MainMenuScene", EventHandler.OnMainMenuPhaseStart));
        ResetStage();
        _currentGamePhase = GamePhase.MainMenu;
    }

    [Button]
    public void GameOver()
    {
        timer.StopTimer();
        StartCoroutine(UnloadGamePhase(_currentGamePhase.ToString() + "Scene"));
        StartCoroutine(LoadGamePhase("GameOverScene", EventHandler.OnGameOverPhaseStart));
        ResetStage();
        _currentGamePhase = GamePhase.GameOver;
    }

    [Button]
    public void WinScreen()
    {
        timer.StopTimer();
        StartCoroutine(UnloadGamePhase(_currentGamePhase.ToString() + "Scene"));
        StartCoroutine(LoadGamePhase("WinScene"));
        ResetStage();
        _currentGamePhase = GamePhase.Win;
    }

    public int GetStageNumber()
    {
        return stageNumber;
    }
}