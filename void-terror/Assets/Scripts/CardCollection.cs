using System;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection
{
    public event Action OnCardCollected;
    private bool hasCard;

    public void AddCard()
    {
        if (!hasCard)
        {
            hasCard = true;
            Debug.Log("Card collected");
            OnCardCollected?.Invoke();
        }
    }

    public bool HasCard()
    {
        return hasCard;
    }
}


