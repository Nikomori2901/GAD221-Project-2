using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VInspector;

public class Minigame : MonoBehaviour
{
    public Image _keyIcon;
    public Slider _slider;
    
    private List<KeyCode> _inputKeys = new List<KeyCode>(new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D });
    private KeyCode _currentKeycode;
    
    public int maxProgress;
    private int _progress;
    
    public Sprite wSprite;
    public Sprite aSprite;
    public Sprite sSprite;
    public Sprite dSprite;

    public int minigameModifier;
    public MinigameStation station;
    
    void Start()
    {
        _slider.maxValue = maxProgress;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(_currentKeycode))
        {
            KeyPress();
        }
        
        else if (Input.anyKeyDown)
        {
            WrongKey();
        }
    }

    public void StartMinigame(MinigameStation minigameStation)
    {
        station = minigameStation;
        minigameModifier = station.minigameModifier;
        _progress = 0;
        _slider.value = _progress;
        gameObject.SetActive(true);
        
        NewKey();
    }
    
    private void KeyPress()
    {
        // noise
        
        _progress += minigameModifier;
        _slider.value = _progress;

        if (_progress >= maxProgress)
        {
            MinigameComplete();
        }

        else
        {
            NewKey();
        }
    }

    public void WrongKey()
    {
        // noise

        if (_progress <= minigameModifier)
        {
            _progress = 0;
        }

        else
        {
            _progress -= minigameModifier;
        }
        
        _slider.value = _progress;
    }

    [Button]
    public void NewKey()
    {
        switch (Random.Range(0, _inputKeys.Count))
        {
            case 0:
                _currentKeycode = _inputKeys[0];
                _keyIcon.sprite = wSprite;
                break;
            case 1:
                _currentKeycode = _inputKeys[1];
                _keyIcon.sprite = aSprite;
                break;
            case 2:
                _currentKeycode = _inputKeys[2];
                _keyIcon.sprite = sSprite;
                break;
            case 3:
                _currentKeycode = _inputKeys[3];
                _keyIcon.sprite = dSprite;
                break;
        }
    }

    private void MinigameComplete()
    {
        Debug.Log("MinigameComplete");
        if (station.morale < 50)
        {
            station.SetMorale(station.morale + 50);
        }

        else
        {
            station.SetMorale(100);
        }
        
        station.minigameActive = false;
        station.StartSpawning();
        station.StartDraining();
        gameObject.SetActive(false);
        
        EventHandler.OnToggleMinigame();
    }

    private void StopMinigame()
    {
        StopAllCoroutines();
        // tells other stuff so it impacts game
        gameObject.SetActive(false);
    }
}
