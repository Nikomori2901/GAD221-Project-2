using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundPile : MonoBehaviour
{
    public Collider2D collider;
    
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        EventHandler.OnFundPileClicked(this);
        Debug.Log("Fund Pile Clicked");
    }
}
