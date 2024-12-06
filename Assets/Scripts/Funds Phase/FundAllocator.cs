using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundAllocator : MonoBehaviour
{
    private AudioSource audioSource;
    
    public List<FundPile> fundPiles = new List<FundPile>();
    public List<FundStation> fundStations = new List<FundStation>();
    
    public FundPile currentFundPile;
    public bool currentlyHolding;
    public FundStation hoveringStation;

    private Vector3 fundPileOriginalPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        InputHandler.current.onM1Up += ReleaseFunds;
        EventHandler.FundPileClicked += GrabFundPile;
    }

    public void GrabFundPile(FundPile fundPile)
    {
        if (!currentlyHolding)
        {
            audioSource.Play();
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
        //EventHandler.OnEmployeeAssigned(currentFundPile);
        Clear();
        //EmployeeSpawner.instance.NextEmployee();
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
        fundPileOriginalPos = Vector3.zero;
        StopAllCoroutines();
    }

    public void Reset()
    {
        Clear();
        
        GameObject.Find("Programming Team").GetComponent<Team>().hasFunds = false;
        GameObject.Find("Design Team").GetComponent<Team>().hasFunds = false;
        GameObject.Find("Art Team").GetComponent<Team>().hasFunds = false;
        GameObject.Find("Audio Team").GetComponent<Team>().hasFunds = false;

        foreach (FundPile fundPile in fundPiles)
        {
            fundPile.transform.position = fundPile.initPos;
            fundPile.collider.enabled = true;
            fundPile.gameObject.SetActive(true);
        }
        
        foreach (FundStation fundStation in fundStations)
        {
            fundStation.gameObject.SetActive(true);
        }
    }
}
