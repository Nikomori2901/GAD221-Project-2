using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundPile : MonoBehaviour
{
    public Collider2D collider;
    public Vector3 initPos;
    
    void Start()
    {
        collider = GetComponent<Collider2D>();
        initPos = transform.position;
    }

    private void OnMouseDown()
    {
        EventHandler.OnFundPileClicked(this);
        Debug.Log("Fund Pile Clicked");
    }
}
