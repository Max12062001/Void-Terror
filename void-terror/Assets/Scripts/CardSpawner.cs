using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab; // The card prefab to spawn
    public Transform[] spawnPoints; // Array of spawn points

    void Start()
    {
        SpawnCard();
    }

    void SpawnCard()
    {
        if (cardPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogError("CardPrefab or SpawnPoints not set!");
            return;
        }

        // Select a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the card at the selected spawn point
        Instantiate(cardPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

