using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAenemy : MonoBehaviour
{
    public Transform[] destinations;
    private int currentDestinationIndex = 0;
    private NavMeshAgent agent;
    private Animator animator;

    private bool isWaiting = false;
    private float waitTime = 3f;
    private float destinationThreshold = 0.1f;

    public LayerMask playerLayer; 
    public float detectionRadius = 40f; 
    public float chaseSpeed = 20f; 

    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        if (destinations.Length > 0)
        {
            MoveAgentToDest();
        }
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else if (isWaiting)
        {
            return;
        }
        else if (agent.remainingDistance <= destinationThreshold && !agent.pathPending)
        {
            StartCoroutine(WaitAtDestination());
        }
        else
        {
            
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0)
        {
            
            StartChasingPlayer();
        }
    }

    private void StartChasingPlayer()
    {
        isChasing = true;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsChasing", true);
    }

    private void ChasePlayer()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (colliders.Length == 0)
        {
           
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        isChasing = false;
        agent.speed = agent.GetComponent<NavMeshAgent>().speed; 
        animator.SetBool("IsChasing", false);
        animator.SetBool("IsWalking", true);
        MoveAgentToDest();
    }

    private void MoveAgentToDest()
    {
        if (currentDestinationIndex >= 0 && currentDestinationIndex < destinations.Length)
        {
            agent.SetDestination(destinations[currentDestinationIndex].position);
            animator.SetBool("IsWalking", true);
            isWaiting = false;
        }
        else
        {
            Debug.Log("out of range.");
        }
    }

    private IEnumerator WaitAtDestination()
    {
        animator.SetBool("IsWalking", false);
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Length;
        MoveAgentToDest();
    }
}
