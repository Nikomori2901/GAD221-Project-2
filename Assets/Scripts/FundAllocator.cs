using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundAllocator : MonoBehaviour
{
    private AudioSource audioSource;
    
    public Employee currentFundPile;
    public bool currentlyHolding;
    public FundStation hoveringStation;

    private Vector3 fundPileOriginalPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        InputHandler.current.onM1Up += ReleaseFunds;
        
        //EventHandler.FundPileClicked += GrabFundPile;
    }

    public void GrabFundPile(Employee employee)
    {
        if (!currentlyHolding)
        {
            audioSource.Play();
            currentFundPile = employee;
            currentFundPile.collider.enabled = false;
            currentlyHolding = true;
            fundPileOriginalPos = employee.transform.position;
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
                ReturnEmployee();
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

    public void ReturnEmployee()
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
}
