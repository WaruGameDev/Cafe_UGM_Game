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

    public Table tableTarget;

    public FoodSO pedido;

    public float timeToThink = 1;
    private float thinkingTime;

    public void ChooseTable(Table table)
    {
        if (table != null)
        {
            tableTarget = table;
            target = table.chair;
            client.clientState = ClientStates.GOING_TO_TABLE;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            // logica de esperar turno
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Table>() == tableTarget && client.clientState == ClientStates.GOING_TO_TABLE)
        {
            client.clientState = ClientStates.THINKING;
            //logica de sentarse

        }

    }

    private void Update()
    {
        switch (client.clientState)
        {
            case ClientStates.THINKING:
                if (thinkingTime < timeToThink)
                {
                    thinkingTime += 1 * Time.deltaTime;
                    if (thinkingTime >= timeToThink)
                    {
                        client.clientState = ClientStates.ORDERNING;
                        Debug.Log("Ordenando");
                        thinkingTime = 0;
                    }
                }
                break;
            case ClientStates.ORDERNING:
                client.clientState = ClientStates.EATING;
                Debug.Log("Comiendo");
                break;
            case ClientStates.EATING:
                client.clientState = ClientStates.LEAVING;
                tableTarget.isOccupied = false;
                target = GameManager.Instance.spawnPoint;
                navMeshAgent.SetDestination(target.position);
                Debug.Log("Pago");
                //pgar
                break;


        }
        
    }

   

}
