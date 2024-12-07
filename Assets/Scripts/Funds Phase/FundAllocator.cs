using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class FundAllocator : MonoBehaviour
{
    private AudioSource audioSource;
    
    public GameObject fundPilePrefab;
    
    public int resourceAmount;
    public int resourcesAssigned;
    
    public FundPile currentFundPile;
    public bool currentlyHolding;
    public FundStation hoveringStation;
    private Vector3 fundPileOriginalPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        InputHandler.current.onM1Up += ReleaseFunds;
        EventHandler.FundPileClicked += GrabFundPile;
        EventHandler.FundsPhaseStart += SetResourceAmount;
    }

    public void SetResourceAmount()
    {
        resourceAmount = 5 - PhaseManager.instance.GetStageNumber();
        resourcesAssigned = 0;
        NewPile();
    }

    [Button]
    public void NewPile()
    {
        if (resourcesAssigned == resourceAmount)
        {
            // Success Feedback
            
            PhaseManager.instance.NextPhase();
        }

        else
        {
            Instantiate(fundPilePrefab);
        }
    }

    public void NewPile(FundPile fundPile)
    {
        NewPile();
    }

    #region Picking Up And Assigning
    public void GrabFundPile(FundPile fundPile)
    {
        if (!currentlyHolding)
        {
            currentFundPile = fundPile;
            currentFundPile.collider.enabled = false;
            currentlyHolding = true;
            fundPileOriginalPos = fundPile.transform.position;
            StartCoroutine(Holding());
        }
    }

    private IEnumerator Holding()
    {
        while (currentlyHolding)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currentFundPile.transform.position.z));
            currentFundPile.transform.position = new Vector3 (mousePos.x, mousePos.y, currentFundPile.transform.position.z);

            yield return new WaitForFixedUpdate();
        }
    }

    public void ReleaseFunds()
    {
        if (currentlyHolding)
        {
            if (hoveringStation)
            {
                AllocateFunds();
            }

            else
            {
                currentFundPile.collider.enabled = true;
                ReturnFundPile();
            }
        }
    }

    // The two hover functions would probably be better off as a raycast but this is a simple solution for prototyping.
    public void HoverStation(FundStation station)
    {
        hoveringStation = station;
    }

    public void UnhoverStation()
    {
        hoveringStation = null;
    }

    public void AllocateFunds()
    {
        currentFundPile.gameObject.SetActive(false);
        hoveringStation.AllocateFunds();
        resourcesAssigned++;
        audioSource.Play();
        NewPile();
        
        Clear();
    }

    public void ReturnFundPile()
    {
        currentFundPile.transform.position = fundPileOriginalPos;
        Clear();
    }

    private void Clear()
    {
        currentFundPile = null;
        currentlyHolding = false;
        hoveringStation = null;
        fundPileOriginalPos = Vector3.zero;
        StopAllCoroutines();
    }

    public void Reset()
    {
        // got removed need to add again
    }
    #endregion
}