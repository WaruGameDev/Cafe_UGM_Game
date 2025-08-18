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
    public NavMeshAgent navMeshAgent;
    public Transform target;

    public FoodSO pedido;    

    public void ChooseTable(Transform chairChosen)
    {
        if (chairChosen != null)
        {
            target = chairChosen;
            client.clientState = ClientStates.GOING_TO_TABLE;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            // logica de esperar turno
        }
    }

   

}
