using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VInspector;

public class Minigame : MonoBehaviour
{
    private Team _team;
    
    private Image _keyIcon;
    private Slider _slider;
    
    private List<KeyCode> _inputKeys = new List<KeyCode>(new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D });
    private KeyCode _currentKeycode;
    
    public int maxProgress;
    private int _progress;

    
    public Sprite wSprite;
    public Sprite aSprite;
    public Sprite sSprite;
    public Sprite dSprite;
    
    // need to set sliders>?!@?
    void Start()
    {
        _keyIcon = GetComponentInChildren<Image>();
        _slider = GetComponentInChildren<Slider>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(_currentKeycode))
        {
            KeyPress();
        }
    }

    public void StartMinigame(Team team)
    {
        _team = team;
        gameObject.SetActive(true);
    }

    [Button]
    public void Test()
    {
        //StartMinigame();
    }
    
    private void KeyPress()
    {
        // noise > increment > complete check > new key
        
        _progress += _team.minigameModifier;

        if (_progress >= maxProgress)
        {
            MinigameComplete();
        }

        else
        {
            NewKey();
        }
    }

    private void NewKey()
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
        // morale gain / complete effects
        
        _team = null;
        gameObject.SetActive(false);
    }

    private void StopMinigame()
    {
        StopAllCoroutines();
    }
    
    // minigame spawns with stats altered by the team spawning it
    // morale is gained and
}
