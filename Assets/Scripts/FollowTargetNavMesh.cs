using UnityEngine;
using UnityEngine.AI;

public class FollowTargetNavMesh : MonoBehaviour
{
    public Transform target; // The target to follow
    
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {          
            agent.SetDestination(target.position);            
        }
    }
}
