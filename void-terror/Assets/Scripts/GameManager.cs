using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float SessionStartTime { get; private set; }
    public int NumChases { get; private set; }  // Made private with public getter to encapsulate data

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SessionStartTime = Time.time;  // Initialize start time in Awake to ensure it's set early
        }
    }

    public float GetSessionTime()
    {
        return Time.time - SessionStartTime;
    }

    public void IncrementChases()
    {
        NumChases++;
    }
}
