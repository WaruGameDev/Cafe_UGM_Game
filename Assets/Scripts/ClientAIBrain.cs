using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

// This script is a placeholder for the AI brain logic
// It can be extended to include various AI behaviors and decision-making processes

public class ClientAIBrain : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> targets; // List of potential targets for the AI to follow

    public int currentTargetIndex = 0; // Index of the current target in the list
    private Transform currentTarget;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (targets.Count > 0)
        {
            currentTarget = targets[0]; // Set the first target as the initial target
            MoveToTarget();
        }
    }
    public void MoveToTarget()
    {
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
        }
    }
    void ChangeTarget(Transform newTarget)
    {
        currentTarget = newTarget;
        MoveToTarget();
    }
    void Update()
    {
        if (currentTarget != null && agent.remainingDistance < agent.stoppingDistance)
        {
            currentTargetIndex++;
            if (currentTargetIndex >= targets.Count)
            {
                currentTargetIndex = 0; // Loop back to the first target
            }
            ChangeTarget(targets[currentTargetIndex]);

        }
     }
}
