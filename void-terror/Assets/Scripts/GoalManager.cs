using UnityEngine;
using TMPro; // Add this if using TextMeshPro

public class GoalManager : MonoBehaviour
{
    public TextMeshProUGUI goalText; // Use TextMeshProUGUI for TextMeshPro
    // public Text goalText; // Use this if you're using the standard Text component

    private string findCardGoal = " Objective: Find the card";
    private string escapeGoal = "Objective: Escape the space station";

    void Start()
    {
        SetGoal(findCardGoal);
    }

    public void SetGoal(string goal)
    {
        if (goalText != null)
        {
            goalText.text = goal;
        }
        else
        {
            Debug.LogWarning("Goal Text is not assigned in the GoalManager.");
        }
    }

    public void OnCardCollected()
    {
        SetGoal(escapeGoal);
    }
}

