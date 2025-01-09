using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public Text sessionTimeText;
    public Text numChasesText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            // Calculate session time
            float sessionTime = GameManager.Instance.GetSessionTime();
            int minutes = Mathf.FloorToInt(sessionTime / 60);
            int seconds = Mathf.FloorToInt(sessionTime % 60);

            // Display session time
            sessionTimeText.text = string.Format("Session Time: {0:00}:{1:00}", minutes, seconds);

            // Display number of chases
            int numChases = GameManager.Instance.NumChases;
            numChasesText.text = "Number of Chases: " + numChases;
        }
        else
        {
            Debug.LogWarning("GameManager instance not found.");
        }
    }

    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0); // Load the main menu scene (index 0)
    }
}

