using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private List<IGameObserver> observers = new List<IGameObserver>();

    // New fields for win condition
    private bool isGameWon = false;
    private float sessionStartTime;
    private int numChases = 0; // Initialize numChases to 0

    void Start()
    {
        currentHealth = maxHealth;
        sessionStartTime = Time.time;
        NotifyHealthChanged();
    }

    void Update()
    {
        // Example logic for counting chases (you can adapt this to your actual game logic)
        if (!isGameWon)
        {
            // Example: If player is being chased, increment numChases
            if (Input.GetKeyDown(KeyCode.C)) // Example key press to simulate chase start
            {
                IncrementChases(); // Increment numChases when chase starts
            }
        }
    }

    public void IncrementChases()
    {
        numChases++;
    }

    public int GetNumChases()
    {
        return numChases;
    }

    public void RegisterObserver(IGameObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IGameObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyHealthChanged()
    {
        foreach (var observer in observers)
        {
            observer.OnHealthChanged(currentHealth);
        }
    }

    // Method to check if game win condition is met (e.g., player reaches exit)
    public void WinGame()
    {
        if (!isGameWon)
        {
            isGameWon = true;
            float sessionDuration = Time.time - sessionStartTime;
            Debug.Log("Game won! Session duration: " + sessionDuration + " seconds");
            Debug.Log("Number of chases: " + numChases);

            // Example: Trigger win screen display or logic here
            // SceneManager.LoadScene("WinScreen"); // Example code to load win screen scene
        }
    }
}
