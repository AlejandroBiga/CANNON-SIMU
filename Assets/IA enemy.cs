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
    private float waitTime = 4f;
    private float destinationThreshold = 0.1f;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
        if(destinations.Length > 0)
        {
            MoveAgentToDest();
        }
        
    }

    private void Update()
    {
        if (isWaiting)
        {
            return;
        }

        if(agent.remainingDistance <= destinationThreshold && !agent.pathPending)
        {
            StartCoroutine(WaitAtDestination());
        }
    }

    private void MoveAgentToDest()
    {
        if(currentDestinationIndex >= 0 &&  currentDestinationIndex < destinations.Length)
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
