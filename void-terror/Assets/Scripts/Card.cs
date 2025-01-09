using UnityEngine;

public class Card : MonoBehaviour
{
    // Other card-related code...

    public void OnPickUp()
    {
        // Notify the GoalManager that the card has been collected
        GoalManager goalManager = FindObjectOfType<GoalManager>();
        if (goalManager != null)
        {
            goalManager.OnCardCollected();
        }

        // Destroy the card object after pickup
        Destroy(gameObject);
    }
}
