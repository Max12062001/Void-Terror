using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Add this namespace for scene management

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float chaseRange = 15f;
    public Transform[] patrolPoints;
    public float patrolSpeed = 3f;
    public float chaseSpeed = 5f;
    public float patrolSpeedMax = 6f;
    public float chaseSpeedMax = 8f;
    public float speedIncreaseInterval = 120f; // 2 minutes

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isChasing = false;
    private float currentSpeed;
    private float speedIncreaseTimer;
    private BackgroundMusicManager musicManager;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        musicManager = FindObjectOfType<BackgroundMusicManager>();

        currentSpeed = patrolSpeed;
        speedIncreaseTimer = 0f;

        if (patrolPoints.Length > 0)
        {
            navMeshAgent.SetDestination(patrolPoints[0].position);
        }
    }

    void Update()
    {
        if (player == null || navMeshAgent == null) return;

        speedIncreaseTimer += Time.deltaTime;
        if (speedIncreaseTimer >= speedIncreaseInterval)
        {
            speedIncreaseTimer = 0f;
            IncreaseSpeed();
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is very close (1 meter) to the monster
        if (distanceToPlayer <= 1f)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Load the main menu scene (scene index 0)
            SceneManager.LoadScene(0);
            return; // Stop further processing in Update after loading the scene
        }

        if (distanceToPlayer <= detectionRange)
        {
            if (!isChasing)
            {
                StartChase();
            }
        }
        else if (distanceToPlayer > chaseRange)
        {
            if (isChasing)
            {
                EndChase();
            }
        }

        if (isChasing)
        {
            navMeshAgent.SetDestination(player.position);
            animator.SetFloat("Speed", chaseSpeed);
        }
        else
        {
            Patrol();
            animator.SetFloat("Speed", currentSpeed);
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            int randomIndex = Random.Range(0, patrolPoints.Length);
            navMeshAgent.SetDestination(patrolPoints[randomIndex].position);
        }
    }

    void IncreaseSpeed()
    {
        if (currentSpeed < patrolSpeedMax)
        {
            currentSpeed += 0.1f;
        }
        if (chaseSpeed < chaseSpeedMax)
        {
            chaseSpeed += 0.1f;
        }
    }

    void StartChase()
    {
        isChasing = true;
        navMeshAgent.speed = chaseSpeed;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.IncrementChases();
        }

        if (musicManager != null)
        {
            musicManager.PlayChaseMusic();
        }
    }

    void EndChase()
    {
        isChasing = false;
        navMeshAgent.speed = currentSpeed;

        if (musicManager != null)
        {
            musicManager.PlayBackgroundMusic();
        }
    }
}

