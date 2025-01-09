using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the goal has been updated to escape the space station
            GoalManager goalManager = FindObjectOfType<GoalManager>();
            if (goalManager != null && goalManager.goalText.text == "Objective: Escape the space station")
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(2); // Load the win screen (scene index 2)
            }
        }
    }
}
