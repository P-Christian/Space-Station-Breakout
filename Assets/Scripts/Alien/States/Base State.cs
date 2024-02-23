using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    Animator animator;
    public NavMeshAgent navMeshAgent;              
    public float startWaitTime = 4;                
    public float timeToRotate = 2;                  
    public float speedWalk = 6;                    
    public float speedRun = 9;                     
 
    public float viewRadius = 15;                   
    public float viewAngle = 90;                    
    public LayerMask playerMask;                    
    public LayerMask obstacleMask;                  
    public float meshResolution = 1.0f;           
    public int edgeIterations = 4;                  
    public float edgeDistance = 0.5f;          
 
 
    public Transform[] waypoints;                 
    int m_CurrentWaypointIndex;                    
 
    Vector3 playerLastPosition = Vector3.zero;      
    Vector3 m_PlayerPosition;                       
 
    float m_WaitTime;                               
    float m_TimeToRotate;                          
    bool m_playerInRange;                           
    bool m_PlayerNear;                              
    bool m_IsPatrol;                               
    bool m_CaughtPlayer;    
    bool m_Attack;                        
 
    void Start()
    {
        animator = GetComponent<Animator>();
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_playerInRange = false;
        m_PlayerNear = false;
        m_WaitTime = startWaitTime;                
        m_TimeToRotate = timeToRotate;
        m_Attack = true;
        m_CurrentWaypointIndex = 0;                 
        navMeshAgent = GetComponent<NavMeshAgent>();
 
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;             
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);  
    }
 
    private void Update()
    {
            EnviromentView();                      
 
        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
    }
 
    private void Chasing()
    {
        
        m_PlayerNear = false;                       
        playerLastPosition = Vector3.zero;  
        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            navMeshAgent.SetDestination(m_PlayerPosition);
            Chase();
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)    
        {
                if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                NChase();
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 4.5f)
                    
                    Stop();
                    NRoam();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    private void Patroling()
    {
        if (m_PlayerNear)
        {
            Roam();
            
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                Roam();
                LookingPlayer(playerLastPosition);
            }
            else
            {
             
                Stop();
                m_TimeToRotate -= Time.deltaTime;
                NRoam();
            }
        }
        else
        {
            m_PlayerNear = false;          
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            Roam();    
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    NRoam();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    private void OnAnimatorMove()
    {

    }
    void Attacks()
    {
        animator.SetTrigger("attack");
        Debug.Log("hit!");
        FindObjectOfType<GameManager>().EndGame();
        Stop();
    }
    void Chase(){
        animator.SetBool("isChasing", true);
        animator.SetBool("isPatroling", false);
    }
    void NChase(){
        animator.SetBool("isChasing", false);
        animator.SetBool("isPatroling", true);
    }
    void Roam(){
        animator.SetBool("isPatroling", true);
    }
    void NRoam(){
        animator.SetBool("isPatroling", false);
        animator.SetBool("isChasing", false);
    }
    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
 
    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
 
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
 
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }

    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                NRoam();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
 
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask); 
        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);         
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_playerInRange = true;             
                    m_IsPatrol = false;                 
                }
                else
                {
                    m_playerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_playerInRange = false;               
            }
            if (m_playerInRange)
            {
                m_PlayerPosition = player.transform.position;       
            }
            if(Vector3.Distance(transform.position, player.position) < 5f)
            {
               Attacks();
            }
        }
    }
}