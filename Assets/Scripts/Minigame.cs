using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    private Team _team;
    
    // progress slider
    private Slider _slider;
    // desiredKey
    private List<KeyCode> _inputKeys = new List<KeyCode>(new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D });
    private KeyCode _currentKeycode;
    
    public int maxProgress;
    private int _progress;

    private SpriteRenderer _keyIcon;
    public Sprite wSprite;
    public Sprite aSprite;
    public Sprite sSprite;
    public Sprite dSprite;
    
    void Start()
    {
        _slider = GetComponent<Slider>();
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

    private void KeyPress()
    {
        _progress += _team.minigameModifier;

        if (_progress >= maxProgress)
        {
            MinigameComplete();
        }

        else
        {
            
        }
    }

    private void MinigameComplete()
    {
        // morale gain
        _team = null;
        gameObject.SetActive(false);
    }

    private void StopMinigame()
    {
        
    }
    
    // minigame spawns with stats altered by the team spawning it
    // random key pops up on screen
    // when player inputs it progress is gained
    // when progress is filled minigame ends
    // morale is gained and
}
