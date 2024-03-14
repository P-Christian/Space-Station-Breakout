using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Attack
}

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;

    private EnemyState currentState;
    private int currentWaypointIndex;
    private float attackTimer;
    private float attackCooldown = 3.0f;
    public float patroldetectionRadius = 10.0f;
    public float chasedetectionRadius = 20.0f;
    public float attackRange = 5.0f;
    public float patrolSpeed = 10.0f;
    public float chaseSpeed = 20.0f;
    private float detectionRadius;

    private void Start()
    {
        currentState = EnemyState.Patrol;
        currentWaypointIndex = 0;
        agent.destination = waypoints[currentWaypointIndex].position;
        attackTimer = 0.0f;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        detectionRadius = patroldetectionRadius;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                PatrolState();
                break;
            case EnemyState.Chase:
                ChaseState();
                break;
            case EnemyState.Attack:
                AttackState();
                break;
        }

        // Face the player
        if (currentState == EnemyState.Chase || currentState == EnemyState.Attack)
        {
            transform.LookAt(player);
        }
    }

    private void PatrolState()
    {
        // This speed variable is for ai patrolling speed.
        agent.speed = patrolSpeed;

        if (agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            agent.destination = waypoints[currentWaypointIndex].position;
        }

        if (CanSeePlayer())
        {
            currentState = EnemyState.Chase;
        }
    }

    private void ChaseState()
    {
        animator.SetBool("isChasing", true);
        agent.destination = player.position;
        agent.speed = chaseSpeed; // Set the agent's speed to chaseSpeed
        detectionRadius = chasedetectionRadius; // Set the detection radius to the chase detection radius

        if (CanAttackPlayer())
        {
            currentState = EnemyState.Attack;
        }
        else if (!CanSeePlayer())
        {
            animator.SetBool("isChasing", false);
            currentState = EnemyState.Patrol;
            detectionRadius = patroldetectionRadius; // Reset the detection radius to the patrol detection radius
        }
    }

    private void AttackState()
    {
        
        if (attackTimer <= 0.0f)
        {

            animator.SetBool("isAttacking", true);

            attackTimer = attackCooldown;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

        if (!CanSeePlayer())
        {
            currentState = EnemyState.Chase;
        }
        else if (Vector3.Distance(transform.position, player.position) > attackRange)
        {
            currentState = EnemyState.Chase;
            animator.SetBool("isAttacking", false);
    }
    }

    private bool CanSeePlayer()
    {
        // This is used for detection, like burb or a magic circle
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    private bool CanAttackPlayer()
    { 
        return (Vector3.Distance(transform.position, player.position) < attackRange);
    }
}