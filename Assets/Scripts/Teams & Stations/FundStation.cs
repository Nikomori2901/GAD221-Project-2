using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void DeallocateFunds()
    {
        _team.hasFunds = false;
    }
}
