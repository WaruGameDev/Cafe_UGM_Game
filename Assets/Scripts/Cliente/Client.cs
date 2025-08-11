using UnityEngine;
using UnityEngine.AI;

public enum ClientStates
{
    WAITING,
    GOING_TO_TABLE,
    THINKING,
    ORDERNING,
    EATING,
    LEAVING 
}

[System.Serializable]
public class ClientClass
{
    public string nameClient;
    public ClientStates clientState = ClientStates.WAITING;

} 

public class Client : MonoBehaviour
{
    public ClientClass client;
    private NavMeshAgent navMeshAgent;
    public Transform target;

    public FoodSO pedido;
   
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (client.clientState)
        {
            case ClientStates.GOING_TO_TABLE:
                navMeshAgent.SetDestination(target.position);
                break;
        }
    }
}
