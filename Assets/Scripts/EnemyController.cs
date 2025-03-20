using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    // Controls enemy based on Player actions
    public Transform player;
    public float chaseSpeed = 5f;
    public float chaseRadius = 7f;
    public float wanderRadius = 10f;
    public GameObject gameOver;
    public Text gameOverText;
    public AudioSource audioSource;

    private bool isChasingPlayer = false;
    private Vector3 wanderPoint;
    private CharacterController characterController;

    void Start()
    {
        wanderPoint = RandomWanderPoint();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isChasingPlayer && IsPlayerInRange())
            ChasePlayer();
        else
            Wander();
    }

    void ChasePlayer()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        characterController.Move(dirToPlayer.normalized * chaseSpeed * Time.deltaTime);
    }

    bool IsPlayerReached()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        return dirToPlayer.magnitude <= 1.1f;
    }

    public void OnPlayerReached()
    {
        gameOver.SetActive(true);
        audioSource.Play();
        gameOverText.text = "You died :(";
        CursorController.EnableCursor();
    }


    void Wander()
    {
        Vector3 direction = (wanderPoint - transform.position).normalized;
        characterController.Move(direction * chaseSpeed * Time.deltaTime);

        // Check if reached the wander point
        if (Vector3.Distance(transform.position, wanderPoint) < 0.1f || IsObstacleBlockingPath())
            wanderPoint = RandomWanderPoint();
    }

    bool IsObstacleBlockingPath()
    {
        RaycastHit hit;
        Vector3 direction = (wanderPoint - transform.position).normalized;

        if (Physics.Raycast(transform.position, direction, out hit, wanderRadius))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }


    Vector3 RandomWanderPoint()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0;
        Vector3 randomPoint = transform.position + randomDirection * Random.Range(wanderRadius * 0.5f, wanderRadius);

        return randomPoint;
    }

    public void SetChasingPlayer(bool chaseState)
    {
        isChasingPlayer = chaseState;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isChasingPlayer)
            OnPlayerReached();
    }

    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= chaseRadius;
    }


}