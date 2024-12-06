using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class FundStation : MonoBehaviour
{
    private Team _team;
    
    public string teamName;

    private void Start()
    {
        _team = GameObject.Find(teamName).GetComponent<Team>();
    }

    public void AllocateFunds()
    {
        _team.hasFunds = true;
        gameObject.SetActive(false);
    }

    [Button]
    public void DeallocateFunds()
    {
        _team.hasFunds = false;
        gameObject.SetActive(true);
    }
}
